Imports Common.Library
Imports AdventureWorks.EntityLayer
Imports System.Collections.ObjectModel
Imports AdventureWorks.DataLayer

Public Class ProductViewModel
    Inherits ViewModelBase

    Sub New()
        LoadProducts()
    End Sub

    Public Property Entity As Product
    Public Property Products As ObservableCollection(Of Product)

    Function LoadProduct(ByVal productId As Integer) As Product
        Return LoadProduct(productId, Nothing)
    End Function

    Function LoadProduct(ByVal productId As Integer, ByVal startingFilePath As String) As Product
        'Hardcode an entity
        Entity = New Product() With {.ProductId = 680, .Name = "HL Road Frame - Black, 58", .ProductNumber = "FR-R92B-58", .Color = "Black", .Size = "58", .Weight = 1016.04D, .StandardCost = 1059.31D, .ListPrice = 1431.5D, .SellStartDate = #6/1/1998 12:00:00 AM#, .SellEndDate = #12/31/2021 12:00:00 AM#}
        Return Entity
    End Function

    Function LoadProducts() As ObservableCollection(Of Product)
        Return LoadProducts(Nothing)
    End Function

    Function LoadProducts(ByVal startingFilePath As String) As ObservableCollection(Of Product)
        Dim mgr = New ProductManager

        Products = mgr.LoadProducts(startingFilePath)

        Return Products
    End Function
End Class
