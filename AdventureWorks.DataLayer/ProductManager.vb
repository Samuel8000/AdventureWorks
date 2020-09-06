Imports System.Collections.ObjectModel
Imports System.Configuration
Imports AdventureWorks.EntityLayer
Imports Common.Library

Public Class ProductManager
    Inherits DataManagerBase

    Function LoadProducts() As ObservableCollection(Of Product)
        Return LoadProducts(Nothing)
    End Function

    Function LoadProducts(ByVal startingFilePath As String) As ObservableCollection(Of Product)
        Dim ret = New ObservableCollection(Of Product)()

        Try
            'attempt to read from XML file
            Dim doc = MyBase.LoadXElement(
                ConfigurationManager.AppSettings("ProductsFile"), startingFilePath)

            Dim products = From prod In doc.<Product>
                           Select New Product With {
                               .ProductId = Convert.ToInt32(prod.Element("ProductID").Value),
                               .Name = prod.Element("Name").Value,
                               .ProductNumber = prod.Element("ProductNumber").Value,
                               .Color = prod.Element("Color").Value,
                               .Size = prod.Element("Size").Value,
                               .Weight = Convert.ToDecimal(prod.Element("Weight").Value),
                               .StandardCost = Convert.ToDecimal(prod.Element("StandardCost").Value),
                               .ListPrice = Convert.ToDecimal(prod.Element("ListPrice").Value),
                               .SellStartDate = Convert.ToDateTime(prod.Element("SellStartDate").Value),
                               .SellEndDate = Convert.ToDateTime(prod.Element("SellEndDate").Value)
                               }
            ret = New ObservableCollection(Of Product)(products.ToList())

        Catch ex As Exception
            Debug.WriteLine(ex.ToString())
        End Try

        Return ret
    End Function

    Function LoadProduct(ByVal productId As Integer) As Product
        Return LoadProduct(productId, Nothing)
    End Function

    Function LoadProduct(ByVal productId As Integer, ByVal startingFilePath As String) As Product
        Dim ret = New Product()

        Try
            Dim list = LoadProducts(startingFilePath)

            If list IsNot Nothing Then
                If list.Count > 0 Then
                    ret = list.FirstOrDefault(Function(p) p.ProductId = productId)
                End If
            End If

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.ToString())
        End Try

        Return ret
    End Function
End Class
