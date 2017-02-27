Imports Catel.Data
Imports Catel.MVVM
Imports System.Collections.ObjectModel
Imports Dragablz
Imports Catel.Services
Imports Catel
Imports Catel.MVVM.Views
Imports CatelAndDragablzTest.Helpers
Imports System.Threading.Tasks
Imports CatelAndDragablzTest.Views

Namespace ViewModels

    ''' <summary>
    ''' 	MainWindow view model.
    ''' </summary>
    Public Class MainWindowViewModel

        Inherits ViewModelBase

#Region "Fields"
        Private Shared _instance As Integer = 0
        Private _viewManager As IViewManager
#End Region 'Fields

#Region "Constructors"

        ''' <summary>
        '''     Called automatically by Catel when the associated view is shown.
        ''' </summary>
        Public Sub New(viewManager As IViewManager)

            Argument.IsNotNull(Function() viewManager)
            _viewManager = viewManager

            _CloseWindow = New TaskCommand(Function() OnCloseWindowExecuteAsync(), Function() OnCloseWindowCanExecute())

            _InterTabClient = New MainWindowInterTabClient()

            _instance += 1
            _IsMain = (_instance = 1)

            ' Restore tabs that were open last time.
            RestoreTabs()
            TabItemsSource = _TabItems
        End Sub

#End Region 'Constructors

#Region "Properties"


        ''' <summary>
        '''     Gets the <see cref="IInterTabClient"/> instance which handles communications with new
        '''     <see cref="TabablzControl"/> instances containing tabs torn off the current instance.
        ''' </summary>
        ''' <value>
        '''     <see cref="IInterTabClient"/>
        '''     <para>
        '''         The <see cref="IInterTabClient"/> instance which handles communications with new
        '''         <see cref="TabablzControl"/> instances containing tabs torn off the current instance.
        '''     </para>
        ''' </value>
        Public ReadOnly Property InterTabClient() As IInterTabClient


        ''' <summary>
        '''     Gets a value that indicates if this instance of <see cref="MainWindowViewModel"/> is
        '''     the view-model for Herbert's main application window.
        ''' </summary>
        ''' <value>
        '''     <see cref="Boolean"/> 
        '''     <para>
        '''         <c>True</c> if this is the view-model of the main application 
        '''         window; Otherwise, <c>False</c>.
        '''     </para>
        ''' </value>
        Public ReadOnly Property IsMain As Boolean


        ''' <summary>
        '''     Gets the collection of tab items open in this instance of <see cref="CatelAndDragablzTest"/>.
        ''' </summary>
        ''' <value>
        '''     <see cref="ObservableCollection(Of HeaderedItemViewModel)"/>
        '''     <para>
        '''         The collection of tab items open in this instance of <see cref="CatelAndDragablzTest"/>.
        '''     </para>
        ''' </value>
        Public ReadOnly Property TabItems() As ObservableCollection(Of HeaderedItemViewModel)


        ''' <summary>
        ''' 	Gets or sets the property value.
        ''' </summary>
        Public Property TabItemsSource() As IEnumerable(Of HeaderedItemViewModel)
            Get
                Return GetValue(Of IEnumerable(Of HeaderedItemViewModel))(TabItemsSourceProperty)
            End Get
            Set(value As IEnumerable(Of HeaderedItemViewModel))
                SetValue(TabItemsSourceProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' 	Register the TabItemsSource property so it is known in the class.
        ''' </summary>
        Public Shared ReadOnly TabItemsSourceProperty As PropertyData = RegisterProperty(NameOf(TabItemsSource), GetType(IEnumerable(Of HeaderedItemViewModel)), Nothing)


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

        ''' <summary>
        ''' 	Register the Title property so it is known in the class. Default value is <c>"View model title"</c>.
        ''' </summary>
        Public Shared ReadOnly TitleProperty As PropertyData = RegisterProperty(NameOf(Title), GetType(String), "Test Catel and Dragablz")
#End Region 'Properties

#Region "Commands"

        ''' <summary>
        '''     Gets the command that closes the window associated with this 
        '''     <see cref="CatelAndDragablzTest"/> instance.
        ''' </summary>
        ''' <value>
        ''' The close window.
        ''' </value>
        Public ReadOnly Property CloseWindow As TaskCommand


        ''' <summary>
        '''     Gets the callback that executes during closing of a Dragablz tab.
        ''' </summary>
        ''' <value>
        '''     <see cref="ItemActionCallback"/> 
        '''     <para>The callback that executes during closing of a tab.</para>
        ''' </value>
        Public Overridable ReadOnly Property ClosingTabItemHandler() As ItemActionCallback
            Get
                Return AddressOf ClosingTabItemHandlerImplementation
            End Get
        End Property


        ''' <summary>
        '''     Callback to handle tab closing.
        ''' </summary>    
        ''' <remarks>
        '''     Useful for disposing stuff, or cancelling the request to close the tab.
        ''' </remarks>
        Private Shared Sub ClosingTabItemHandlerImplementation(args As ItemActionCallbackArgs(Of TabablzControl))
            ' Here's the view model:
            ' Dim viewModel = TryCast(args.DragablzItem.DataContext, HeaderedItemViewModel)

            MessageBox.Show($"Closing {args.Owner.Name}.{args.DragablzItem.Content}, {args.Owner.Items.Count - 1} tabs remain")

            ' Here's how you can cancel the closing of the tab:
            'args.Cancel() 
        End Sub


        ''' <summary>
        '''     Called when the <see cref="CloseWindow"/> command is about to execute. Returns
        '''     <c>True</c> if execution of the command should be allowed.
        ''' </summary>
        ''' <returns>
        '''     <see cref="Boolean"/> 
        '''     <c>True</c> if execution of the <see cref="CloseWindow"/> command should be allowed;
        '''     otherwise <c>False</c>.
        ''' </returns>
        Private Function OnCloseWindowCanExecute() As Boolean
            ' May need to prevent window closing in future (e.g. to allow data to be saved).
            Return True
        End Function


        ''' <summary>
        '''     Called when the CloseWindow command is being executed in response to a UI event.
        ''' </summary>
        Private Async Function OnCloseWindowExecuteAsync() As Task
            If IsMain Then
                Application.Current.Shutdown()
            Else
                ' Close the child window associated with this view model.
                Dim views() = _viewManager.GetViewsOfViewModel(Me)
                For Each view As IView In views
                    Dim mainWindowView = CType(view, MainWindow)
                    mainWindowView.Close()
                Next
            End If
        End Function

#End Region 'Commands

#Region "Methods"
        ' TODO: Create your methods here
#End Region 'Methods

#Region "Helpers"

        Private Sub RestoreTabs()
            _TabItems = New ObservableCollection(Of HeaderedItemViewModel)

            If IsMain Then
                _TabItems.Add(New HeaderedItemViewModel() With {.Header = "Projects", .Content = "Test"})
            End If
        End Sub

#End Region
    End Class

End Namespace