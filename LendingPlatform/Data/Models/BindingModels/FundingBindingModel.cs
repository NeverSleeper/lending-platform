namespace LendingPlatform.Data.Models {
    using System;
    using System.ComponentModel.DataAnnotations;
    using LendingPlattform.Helper;

    /// <summary>
    /// This binding model is for sending an investor funding for
    /// a single project.
    /// </summary>
    /// <remarks> The InvestorId is only here for the POC,
    /// usually the UserManager would take care of the user
    /// (here an investor). 
    /// </remarks>
    public class FundingBindingModel {

        [Required, ValidGuid]
        public Guid InvestorId { get; init; }

        [Required]
        public int Amount { get; init; }
    }



}