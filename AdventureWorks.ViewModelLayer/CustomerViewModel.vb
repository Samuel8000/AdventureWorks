Imports Common.Library
Imports AdventureWorks.EntityLayer

Public Class CustomerViewModel
    Inherits ViewModelBase

    Sub New()
        LoadCustomer(1)
    End Sub
    Public Property Entity As Customer

    Function LoadCustomer(ByVal customerId As Integer) As Customer
        Entity = New Customer() With {.CustomerId = 1, .FirstName = "Bruce", .LastName = "Wayne", .CompanyName = "Wayne Enterprises"}

        Return Entity
    End Function
End Class
