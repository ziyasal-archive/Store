using System;
using System.Reflection;
using WPFArch.UI.BusinessLayer.Common;
using WPFArch.UI.BusinessLayer.CustomerServiceReference;
using WPFArch.UI.BusinessLayer.ServiceManagerInterface;

namespace WPFArch.UI.BusinessLayer.ServiceManagerImpl
{
    public class CustomerServiceManager : ICustomerServiceManager
    {
        public void AddCustomer(string firstName, string lastName)
        {
            CustomerServiceClient customerServiceClient = new CustomerServiceClient();
            try
            {
                customerServiceClient.AddCustomer(new AddCustomerRequest
                                                      {
                                                          CustomerDto = new CustomerDto
                                                                            {
                                                                                FirstName = firstName,
                                                                                LastName = lastName
                                                                            }

                                                      });
            }
            catch (Exception exception)
            {
                string message = string.Format("An error occured while in type :{0} , method :{1} ", "CustomerServiceManager", MethodBase.GetCurrentMethod().Name);
                CommonLogManager.Log.Error(message, exception);
                throw;
            }
            finally
            {
                customerServiceClient.Close();
            }
        }

        public void UpdateCustomer(CustomerDto customerDto)
        {
            CustomerServiceClient customerServiceClient = new CustomerServiceClient();
            try
            {
                customerServiceClient.UpdateCustomer(new UpdateCustomerRequest
                                                         {
                                                             CustomerDto = customerDto
                                                         });
            }
            catch (Exception exception)
            {
                string message = string.Format("An error occured while in type :{0} , method :{1} ", "CustomerServiceManager", MethodBase.GetCurrentMethod().Name);
                CommonLogManager.Log.Error(message, exception);
                throw;
            }
            finally
            {
                customerServiceClient.Close();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            CustomerServiceClient customerServiceClient = new CustomerServiceClient();
            try
            {
                customerServiceClient.DeleteCustomer(new DeleteCustomerRequest
                                                         {
                                                             CustomerID = customerId
                                                         });
            }
            catch (Exception exception)
            {
                string message = string.Format("An error occured while in type :{0} , method :{1} ", "CustomerServiceManager", MethodBase.GetCurrentMethod().Name);
                CommonLogManager.Log.Error(message, exception);
                throw;
            }
            finally
            {
                customerServiceClient.Close();
            }
        }

        public void GetCustomers(Action<GetCustomersResponse, Exception> callback)
        {
            CustomerServiceClient customerServiceClient = new CustomerServiceClient();
            try
            {
                customerServiceClient.GetCustomersCompleted += (s, e) => callback(e.Result, e.Error);
                customerServiceClient.GetCustomersAsync();
            }
            catch (Exception exception)
            {
                string message = string.Format("An error occured while in type :{0} , method :{1} ", "CustomerServiceManager", MethodBase.GetCurrentMethod().Name);
                CommonLogManager.Log.Error(message, exception);
                throw;
            }
            finally
            {
                customerServiceClient.Close();
            }
        }
    }
}