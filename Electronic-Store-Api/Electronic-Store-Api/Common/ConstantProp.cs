namespace Electronic_Store_Api.Common
{
    public class ConstantProp
    {
        public const string dataBaseName = "electronicsAppDb";
        public const string statusDbParam = "@Status";
        public const string errMsgDbParam = "@ErrorMessage";
        public const string status = "Status";
        public const string errMsg = "ErrorMessage";

        public const string controllerIn = "ControllerIn";
        public const string controllerOut = "ControllerOut";
        public const string serviceIn = "ServiceIn";
        public const string serviceOut = "ServiceOut";

        public const string userPk = "UserPK";
        public const string userId = "UserID";
        public const string userType = "UserType";
        public const string language = "Language";
        public const string uEditVersion = "UEditVersion";
        public const string componentId = "ComponentID";

        public const string modeDbParam = "@Mode";

        public const string insert = "INSERT";
        public const string retrieve = "RETRIEVE";
        public const string update = "UPDATE";
        public const string delete = "DELETE";

        public const string policyPkDbParam = "@PolicyPk";
        public const string tranPkDbParam = "@TranPk";
        public const string accountPkDbParam = "@AccountPk";
        public const string outPaymentPlanDbParam = "@OutPaymentPlan";
        public const string outPaymentplan = "OutPaymentPlan";
        public const string outPaymentPkDbParam = "@OutPaymentLogPk";
        public const string outPaymentlogPk = "OutPaymentLogPk";
        public const string asUserPk = "@AsUserPk";
        public const string inputFrom = "@InputFrom";

        public const string termPkDbParam = "@TermPk";

        public const string strpolicyNoparam = "@PolicyNo";
        public const string strToken_IDparam = "@TokenID";
        public const string strModeparam = "@Mode";
        public const string strCustomerIDparam = "@CustomerID";
        public const string strTokenIDparam = "@tokenId";
        public const string strLastFourparam = "@LastFour";

        public const string strURIConfig = "OneIncPaymentURI";
        public const string strProcessURIConfig = "OneIncProcessURI";
        public const string strPortalOneAuthKey = "PortalOneAuthKey";
        public const string strProcessOneAuthKey = "ProcessOneAuthKey";
        public const string strTokenReuse = "TokenReuse";
        public const string strMakePayment = "makePayment";
        public const string strsavePayment = "savePaymentMethod";
        public const string strOneIncAgentPaymentURI = "OneIncAgentPaymentURI";
        public const string strAgentPortalOneAuthKey = "AgentPortalOneAuthKey";

        public const string policyNo = "@policyNo";
        public const string postalCode = "@postalCode";
        public const string strpAccountNoparam = "@AccountNo";

        public const string strTansIDparam = "@transactionId";
        public const string strpostedAmountparam = "@postedAmount";
        public const string strmessageparam = "@message";
        public const string strTransDateparam = "@transactionDate";
        public const string strSource = "@Source";
        public const string policyNumber = "@PolicyNumber";
        public const string zipCode = "@ZipCode";

        public const string strSessionIDConfig = "Api/Api/Session/Create";
        public const string strAccountConfig = "Api/Api/Customer/CreateAccount";
        public const string strEnrollAutoPayCCConfig = "api/CreditCard/Charge";
        public const string strEnrollAutoPayECPConfig = "api/Eft/Save";
        public const string strRecurringCCConfig = "api/CreditCard/charge";
        public const string strRecurringECPConfig = "api/Eft/Debit";

        public const string strLogPath = "LogPath";

        public const long pkMax = 999999999999999999;

        //Agency Commission Payment
        public const string strAgentConfig = "Outbound/api/BankAccount/Credit";
        public const string strAgencyCommissionURIConfig = "OneIncAgencyCommissionURI";
        public const string strAgencyCommissionlOneAuthKey = "PortaAgencyCommissionlOneAuthKey";

        public const string AccountType = "@AccountType";
        public const string BankName = "@BankName";
        public const string Description = "@Description";
        public const string PaymentStatus = "@PaymentStatus";

        public const string cardType = "@CardType";
        public const string cardExpirationMonth = "@CardExpirationMonth";
        public const string cardExpirationYear = "@CardExpirationYear";
        public const string customerName = "@CustomerName";
        public const string holderZip = "@HolderZip";
        public const string sessionId = "@SessionId";
        public const string lastFourDigits = "@LastFourDigits";
        public const string tokenId = "@TokenId";
        public const string timeZone = "@TimeZone";
        public const string transactionDate = "@TransactionDate";
        public const string paymentCategory = "@PaymentCategory";
        public const string commissionSchedule = "@CommissionSchedule";
        public const string installmentPlanStatus = "@InstallmentPlanStatus";

        // Basic Authentication
        public const string userIdDbParam = "@UserId";
        public const string passwordDbParam = "@Password";

    }
}
