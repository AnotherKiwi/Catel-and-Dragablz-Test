Imports Catel.Windows

Namespace Views

    ''' <summary>
    ''' 	Interaction logic for MainWindow.xaml.
    ''' </summary>
    Public Partial Class MainWindow
        Inherits DataWindow
        ''' <summary>
        ''' 	Initializes a new instance of the <see cref="MainWindow"/> class.
        ''' </summary>
        Public Sub New()
            MyBase.New(Nothing, DataWindowMode.Custom)
            InitializeComponent()
        End Sub
    End Class

End Namespace
