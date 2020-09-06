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
        Dim mgr = New ProductManager

        Entity = mgr.LoadProduct(productId, startingFilePath)

        RaisePropertyChanged("Entity")

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
