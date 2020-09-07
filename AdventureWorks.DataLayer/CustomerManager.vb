Imports System.Collections.ObjectModel
Imports System.Configuration
Imports AdventureWorks.EntityLayer
Imports Common.Library

Public Class CustomerManager
    Inherits DataManagerBase


    Function LoadCustomers(ByVal startingFilePath As String) As ObservableCollection(Of Customer)
        Dim ret = New ObservableCollection(Of Customer)()

        Try
            Dim doc = MyBase.LoadXElement(
                ConfigurationManager.AppSettings("CustomersFile"), startingFilePath)

            Dim customers = From cust In doc.<Customer>
                            Select New Customer With {
                                .CustomerId = Convert.ToInt32(cust.Element("CustomerID").Value),
                                .CompanyName = cust.Element("CompanyName").Value,
                                .FirstName = cust.Element("FirstName").Value,
                                .LastName = cust.Element("LastName").Value
                }

            ret = New ObservableCollection(Of Customer)(customers.ToList())
        Catch ex As Exception
            Debug.WriteLine(ex.ToString())
        End Try

        Return ret
    End Function

    Function LoadCustomer(ByVal customerId As Integer) As Customer
        Return LoadCustomer(customerId, Nothing)
    End Function

    Function LoadCustomer(ByVal customerId As Integer, ByVal startingFilePath As String) As Customer
        Dim ret = New Customer()

        Try
            Dim list = LoadCustomers(startingFilePath)
            If list IsNot Nothing Then
                If list.Count > 0 Then
                    ret = list.FirstOrDefault(Function(c) c.CustomerId = customerId)
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return ret
    End Function
End Class
