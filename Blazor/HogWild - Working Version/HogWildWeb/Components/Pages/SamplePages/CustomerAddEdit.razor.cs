using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HogWildWeb.Components.Pages.SamplePages
{
	partial class CustomerAddEdit
	{
		#region Fields
		[Parameter]
		public int CustomerID { get; set; } = 0;

		private MudForm customerForm = new();

		// The feedback message
		private string feedbackMessage = string.Empty;

		// The error message
		private string errorMessage = string.Empty;

		// has feedback
		private bool hasFeedback => !string.IsNullOrWhiteSpace(feedbackMessage);

		// has error
		private bool hasError => !string.IsNullOrWhiteSpace(errorMessage);

		// error details
		private List<string> errorDetails = new();

		private List<HogWildSystemV2.ViewModels.LookupView> countries = new();
		private List<HogWildSystemV2.ViewModels.LookupView> provinces = new();
		private List<HogWildSystemV2.ViewModels.LookupView> statusLookup = new();		

		private HogWildSystemV2.ViewModels.CustomerView customer = new();
		#endregion

		#region Properties
		[Inject]
		protected HogWildSystemV2.BLL.CustomerService CustomerServiceV2 { get; set; } = default!;
		#endregion

		#region Validation
		private bool isFormValid;
		private bool hasDataChanged;
		#endregion

		private void Save()
		{
			// clear previous error details and messages
			errorDetails.Clear();
			errorMessage = string.Empty;
			feedbackMessage = String.Empty;

			// wrap the service call in a try/catch to handle unexpected exceptions
			try
			{
				var result = CustomerServiceV2.AddEditCustomer(customer);
				if (result.IsSuccess)
				{
					feedbackMessage = "";
				}
				else
				{
					errorMessage = "Errors";
					errorDetails = GetErrorMessages(result.Errors.ToList());
				}
			}
			catch (Exception ex)
			{
				// capture any exception message for display
				errorMessage = ex.Message;
			}
		}

		public static List<string> GetErrorMessages(List<BYSResults.Error> errorMessage)
		{
			// Initialize a new list to hold the extracted error messages
			List<string> errorList = new();

			// Iterate over each Error object in the incoming list
			foreach (var error in errorMessage)
			{
				// Convert the current Error to its string form and add it to errorList
				errorList.Add(error.ToString());
			}

			// Return the populated list of error message strings
			return errorList;
		}
	}
}
