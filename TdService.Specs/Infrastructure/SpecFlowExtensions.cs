// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecFlowExtensions.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The spec flow extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs.Infrastructure
{
    /// <summary>
    /// The spec flow extensions.
    /// </summary>
    public static class SpecFlowExtensions
    {
        /// <summary>
        /// The replace error code with message.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        /// <returns>
        /// The <see cref="TechTalk.SpecFlow.Table"/>.
        /// </returns>
        public static TechTalk.SpecFlow.Table ReplaceErrorCodeWithMessage(this TechTalk.SpecFlow.Table table)
        {
            const string RuleHeader = "Rule";
            const string ErrorCodeHeader1 = "ErrorCode";
            const string ErrorCodeHeader2 = "Error Code";

            if (!table.ContainsColumn(RuleHeader))
            {
                return table;
            }

            if (table.ContainsColumn(ErrorCodeHeader1))
            {
                foreach (var row in table.Rows)
                {
                    var code = row[ErrorCodeHeader1];
                    if (code != null)
                    {
                        row[RuleHeader] = Resources.ErrorCodeResources.ResourceManager.GetString(code);
                    }
                }
            }

            if (table.ContainsColumn(ErrorCodeHeader2))
            {
                foreach (var row in table.Rows)
                {
                    var code = row[ErrorCodeHeader2];
                    if (code != null)
                    {
                        row[RuleHeader] = Resources.ErrorCodeResources.ResourceManager.GetString(code);
                    }
                }
            }

            return table;
        }
    }
}