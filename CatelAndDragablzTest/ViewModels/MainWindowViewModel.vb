Imports Catel.Data
Imports Catel.MVVM
Imports System.Collections.ObjectModel
Imports $rootnamespace$.Models
Imports $rootnamespace$.Services

Namespace ViewModels

    ''' <summary>
    ''' 	MainWindow view model.
    ''' </summary>
    Public Class MainWindowViewModel

        Inherits ViewModelBase

#Region "Fields"
#End Region 'Fields

#Region "Constructors"
        ''' <summary>
        ''' 	Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        ''' </summary>
        Public Sub New()
        End Sub
#End Region 'Constructors

#Region "Properties"
        ''' <summary>
        ''' 	Gets the title of the view model.
        ''' </summary>
        ''' <value>The title.</value>
        Public Overrides Property Title() As String
            Get
                Return GetValue(Of String)(NameOf(Title))
            End Get
            Protected Set(value As String)
                SetValue(NameOf(Title), value)
            End Set
        End Property

        ' TODO: Register models with the vmpropmodel codesnippet
        ' TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets

#Region "Property Registrations"
        ''' <summary>
        ''' 	Register the Title property so it is known in the class. Default value is <c>"View model title"</c>.
        ''' </summary>
        Public Shared ReadOnly TitleProperty As PropertyData = RegisterProperty(NameOf(Title), GetType(String), "View model title")
#End Region 'Property Registrations
#End Region 'Properties

#Region "Commands"
        ' TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets
#End Region 'Commands

#Region "Methods"
        ' TODO: Create your methods here
#End Region 'Methods
    End Class

End Namespace