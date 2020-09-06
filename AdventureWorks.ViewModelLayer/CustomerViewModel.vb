Imports Common.Library
Imports AdventureWorks.EntityLayer
Imports System.Collections.ObjectModel
Imports AdventureWorks.DataLayer

Public Class CustomerViewModel
    Inherits ViewModelBase

    Sub New()
        LoadCustomer(1)
    End Sub

    Public Property Customers As ObservableCollection(Of Customer)
    Public Property Entity As Customer

    Function LoadCustomers() As ObservableCollection(Of Customer)
        Return LoadCustomers(Nothing)
    End Function

    Function LoadCustomers(ByVal startingFilePath As String) As ObservableCollection(Of Customer)
        Dim mgr = New CustomerManager

        Customers = mgr.LoadCustomers(startingFilePath)

        Return Customers
    End Function

    Function LoadCustomer(ByVal customerId As Integer) As Customer
        Entity = New Customer() With {.CustomerId = 1, .FirstName = "Bruce", .LastName = "Wayne", .CompanyName = "Wayne Enterprises"}

        Return Entity
    End Function
End Class
