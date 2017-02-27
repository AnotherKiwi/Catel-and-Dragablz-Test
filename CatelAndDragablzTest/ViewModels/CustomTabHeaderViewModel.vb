Imports Catel.Data
Imports Catel.MVVM

Namespace ViewModels

    Public Class CustomTabHeaderViewModel

        Inherits ViewModelBase

        ''' <summary>
        ''' 	Gets or sets the Header property value.
        ''' </summary>
        Public Property Header() As String
            Get
                Return GetValue(Of String)(HeaderProperty)
            End Get
            Set(value As String)
                SetValue(HeaderProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' 	Register the Header property so it is known in the class.
        ''' </summary>
        Public Shared ReadOnly HeaderProperty As PropertyData = RegisterProperty(NameOf(Header), GetType(String), Nothing)

        ''' <summary>
        ''' 	Gets or sets the IsSelected property value.
        ''' </summary>
        Public Property IsSelected() As Boolean
            Get
                Return GetValue(Of Boolean)(IsSelectedProperty)
            End Get
            Set(value As Boolean)
                SetValue(IsSelectedProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' 	Register the IsSelected property so it is known in the class.
        ''' </summary>
        Public Shared ReadOnly IsSelectedProperty As PropertyData = RegisterProperty(NameOf(IsSelected), GetType(Boolean), Nothing)

    End Class
End Namespace