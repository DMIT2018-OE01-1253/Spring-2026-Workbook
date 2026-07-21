using HogWildSystem.ViewModels;

namespace HogWildWeb.Components.Pages.SamplePages
{
    public partial class SimpleNonIndexList
    {
        protected List<CustomerEditView> Customers { get; set; } = new();
		private string customerFName { get; set; } = string.Empty;
		private string customerLName { get; set; } = string.Empty;

		#region Error Handling
		// The error message
		private string errorMessage = string.Empty;

		// has error
		private bool hasError => !string.IsNullOrWhiteSpace(errorMessage);

		// error details
		private List<string> errorDetails = new();
		#endregion

		private void RemoveCustomer(int customerId)
        {
            var selectedItem =
                Customers.FirstOrDefault(x => x.CustomerID == customerId);
            if (selectedItem != null)
            {
                Customers.Remove(selectedItem);
            }
        }

        private async Task AddCustomerToList()
        {
			// clear previous error details and messages
			errorDetails.Clear();
			errorMessage = string.Empty;

			if (string.IsNullOrWhiteSpace(customerFName))
            {
                errorMessage = "Missing Information";
                errorDetails.Add("Customer First Name is required.");
			}
            else if (string.IsNullOrWhiteSpace(customerLName))
			{
				errorMessage = "Missing Information";
				errorDetails.Add("Customer Last Name is required.");
			}
            else
            {
                int maxID = Customers.Any() ? Customers.Max(x => x.CustomerID) + 1 : 1;
                Customers.Add(new CustomerEditView()
                {
                    CustomerID = maxID,
                    FirstName = customerFName,
                    LastName = customerLName
                });

				customerFName = string.Empty;
				customerLName = string.Empty;

				await InvokeAsync(StateHasChanged);
            }
        }
    }
}
