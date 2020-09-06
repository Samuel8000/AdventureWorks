Imports AdventureWorks.ViewModelLayer

Public Class ProductDetailControl
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _viewModel = DirectCast(Me.Resources("viewModel"), ProductViewModel)
    End Sub

    Private _viewModel As ProductViewModel
    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        _viewModel.LoadProduct(706)
    End Sub
End Class
