﻿namespace TdService.Services.Implementations
{
    using System.Collections.Generic;
    using TdService.Model.Balance;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Transactions;
    using TdService.Services.Mapping;
    using System;
    using TdService.Resources;
    using TdService.Services.Base;
    using TdService.Infrastructure.Logging;

    public class TransactionService : ServiceBase, ITransactionService
    {
        private readonly ITransactionsRepository transactionsRepository;

        public TransactionService(ITransactionsRepository transactionsRepository, ILogger logger)
            : base(logger)
        {
            this.transactionsRepository = transactionsRepository;
        }

        public List<GetTransactionsResponse> GetTransactionsForUser(GetTransactionsRequest request)
        {
            var result = this.transactionsRepository.GetTransactionsForUser(request.IdentityToken);
            return result.ConvertToGetTransactionsResponseCollection();
        }

        public AddTransactionResponse AddTransaction(AddTransactionRequest request)
        {
            var response = new AddTransactionResponse();
            response.MessageType = Messaging.MessageType.Success;
            try
            {
                var transaction = request.ConvertToTransaction();
                transaction.WalletId = request.WalletId;
                var result = this.transactionsRepository.AddTransaction(transaction);
                response = result.ConvertToAddTransactionResponse();
            }
            catch (Exception e)
            {
                response.MessageType = Messaging.MessageType.Error;
                response.Message = e.Message;
            }
            return response;
        }

        public ConfirmPayPalTransactionResponse ConfirmPayPalTransaction(ConfirmPayPalTransactionRequest request)
        {
            var response = new ConfirmPayPalTransactionResponse();
            response.MessageType = Messaging.MessageType.Success;
            try
            {
                this.transactionsRepository.ConfirmTransaction(request.Token, request.PayerId);

                return response;
            }
            catch (Exception e)
            {
                response.MessageType = Messaging.MessageType.Error;
                response.Message = e.Message;
            }
            return response;
        }


        public CancelPayPalTransactionResponse CancelPayPalTransaction(CancelPayPalTransactionRequest request)
        {
            var response = new CancelPayPalTransactionResponse();
            try
            {
                this.transactionsRepository.CancelTransaction(request.Token);
                response.MessageType = Messaging.MessageType.Success;
                response.Message = CommonResources.TransacionCanceledMessage;
                return response;
            }
            catch (Exception e)
            {
                response.MessageType = Messaging.MessageType.Error;
                response.Message = e.Message;
            }
            return response;
        }
    }
}
