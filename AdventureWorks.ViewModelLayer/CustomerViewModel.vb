Imports Common.Library
Imports AdventureWorks.EntityLayer
Imports System.Collections.ObjectModel
Imports AdventureWorks.DataLayer

Public Class CustomerViewModel
    Inherits ViewModelBase

    Sub New()
        LoadCustomers()
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
        Return LoadCustomer(customerId, Nothing)
    End Function

    Function LoadCustomer(ByVal customerId As Integer, ByVal startingFilePath As String) As Customer
        Dim mgr As New CustomerManager
        Entity = mgr.LoadCustomer(customerId, startingFilePath)
        Return Entity
    End Function
End Class
