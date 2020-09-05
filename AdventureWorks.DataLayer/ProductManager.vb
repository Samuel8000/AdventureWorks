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
                               .ProductId = Convert.ToInt32(prod.Element("ProductID")),
                               .Name = prod.Element("Name").Value,
                               .ProductNumber = prod.Element("ProductNumber").Value,
                               .Color = prod.Element("Color").Value,
                               .Size = prod.Element("Size").Value,
                               .Weight = Convert.ToDecimal(prod.Element("Weight")),
                               .StandardCost = Convert.ToDecimal(prod.Element("StandardCost")),
                               .ListPrice = Convert.ToDecimal(prod.Element("ListPrice")),
                               .SellStartDate = Convert.ToDateTime(prod.Element("SellStartDate")),
                               .SellEndDate = Convert.ToDateTime(prod.Element("SellEndDate"))
                               }
            ret = New ObservableCollection(Of Product)(products.ToList())

        Catch ex As Exception
            Debug.WriteLine(ex.ToString())
        End Try

    End Function
End Class
