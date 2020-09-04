
Public Class Product
    Inherits CommonBase

    Sub New()
        StandardCost = 500
        ListPrice = 900
        SellStartDate = DateTime.Now
    End Sub
    Public Property ProductId As Integer
    Public Property Name As String
    Public Property ProductNumber As String
    Public Property Color As String
    Public Property StandardCost As Decimal
    Public Property ListPrice As Decimal
    Public Property Size As String
    Public Property Weight As Decimal
    Public Property SellStartDate As DateTime
    Public Property SellEndDate As DateTime

    Sub CalculateSellEndDate(ByVal days As Integer, ByRef sellDate As DateTime)
        SellEndDate = SellStartDate.AddDays(days)
        ' set the ByRef parameter
        sellDate = SellEndDate
    End Sub

    Function CalculateSellEndDateFunction(ByVal days As Integer) As DateTime
        SellEndDate = SellStartDate.AddDays(days)
        Return SellEndDate
    End Function

    Overloads Function CalculateProfit() As Decimal
        Return CalculateProfit(StandardCost)
    End Function

    Overloads Function CalculateProfit(ByVal newCost As Decimal) As Decimal
        If newCost <> 0 Then
            StandardCost = newCost
        End If
        Return ListPrice - StandardCost
    End Function

    Shared Function CalculateTheProfit(ByVal cost As Decimal, ByVal price As Decimal) As Decimal
        Return price - cost
    End Function

    Protected Overrides Function GetClassData() As String
        Dim sb As New Text.StringBuilder(1024)

        sb.AppendLine("Product Id: " + ProductId.ToString())
        sb.AppendLine("Product Name: " + Name)
        sb.AppendLine("Product Number: " + ProductNumber)
        sb.AppendLine(MyBase.GetClassData())

        Return sb.ToString()
    End Function

End Class
