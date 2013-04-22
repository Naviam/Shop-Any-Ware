// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionService.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The transaction service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using TdService.Infrastructure.Email;
    using TdService.Infrastructure.Logging;
    using TdService.Model.Balance;
    using TdService.Resources;
    using TdService.Services.Base;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging.Package;
    using TdService.Services.Messaging.Transactions;

    /// <summary>
    /// The transaction service.
    /// </summary>
    public class TransactionService : ServiceBase, ITransactionService
    {
        /// <summary>
        /// The email service.
        /// </summary>
        private readonly IEmailService emailService;

        /// <summary>
        /// The transactions repository.
        /// </summary>
        private readonly ITransactionsRepository transactionsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// </summary>
        /// <param name="transactionsRepository">
        /// The transactions repository.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public TransactionService(ITransactionsRepository transactionsRepository, IEmailService emailService, ILogger logger)
            : base(logger)
        {
            this.transactionsRepository = transactionsRepository;
            this.emailService = emailService;
        }

        /// <summary>
        /// The get transactions for user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The collection of get transactions responses.
        /// </returns>
        public List<GetTransactionsResponse> GetTransactionsForUser(GetTransactionsRequest request)
        {
            var result = this.transactionsRepository.GetTransactionsForUser(request.IdentityToken);
            return result.ConvertToGetTransactionsResponseCollection();
        }

        /// <summary>
        /// The add transaction.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="AddTransactionResponse"/>.
        /// </returns>
        public AddTransactionResponse AddTransaction(AddTransactionRequest request)
        {
            var response = new AddTransactionResponse { MessageType = Messaging.MessageType.Success };
            try
            {
                var transaction = request.ConvertToTransaction();
                transaction.WalletId = request.WalletId;
                transaction.OperationType = OperationType.PayPalBalanceLoad;
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

        /// <summary>
        /// The confirm pay pal transaction.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ConfirmPayPalTransactionResponse"/>.
        /// </returns>
        public ConfirmPayPalTransactionResponse ConfirmPayPalTransaction(ConfirmPayPalTransactionRequest request)
        {
            var response = new ConfirmPayPalTransactionResponse { MessageType = Messaging.MessageType.Success };
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

        /// <summary>
        /// The cancel pay pal transaction.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="CancelPayPalTransactionResponse"/>.
        /// </returns>
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

        /// <summary>
        /// The add package payment transaction.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="PayForPackageResponse"/>.
        /// </returns>
        public PayForPackageResponse AddPackagePaymentTransaction(PayForPackageRequest request)
        {
            try
            {
                var tuple = this.transactionsRepository.AddPackagePaymentTransaction(request.PackageId);
                var package = tuple.Item1;
                var result = package.ConvertToPayForPackageResponse();
                if (package.User.Activated)
                {
                    var profile = package.User.Profile;
                    this.emailService.SendMail(
                        EmailResources.EmailActivationFrom,
                        package.User.Email,
                        profile.GetEmailResourceString("PackageStatusChangedSubject"),
                        string.Format(
                            profile.GetEmailResourceString("PackageStatusChangedBody"),
                            package.Name,
                            package.Id,
                            profile.GetTranslatedPackageStatus("Assembled"),
                            profile.GetTranslatedPackageStatus("Paid"),
                            profile.GetFullName()));
                }

                result.Message = string.Format(CommonResources.TransactionPaymentSucceded, package.Id);
                result.MessageType = Messaging.MessageType.Success;
                result.WalletAmount = tuple.Item2;
                return result;
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex.Message);
                return new PayForPackageResponse
                           {
                               MessageType = Messaging.MessageType.Error,
                               Message = CommonResources.TransactionPaymentError
                           };
            }
        }
    }
}