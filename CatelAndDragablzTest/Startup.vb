Imports Catel.Logging
Imports CatelAndDragablzTest.Views
Imports Dragablz
Imports Dragablz.Dockablz

''' <summary>
'''     Enables single instance mode for Herbert.NET.
''' </summary>
''' <remarks>
'''     Based on code from "Pro WPF 4.5 in VB: Windows Presentation Foundation in .NET 4.5"
'''     by Matthew MacDonald (see page 570).
''' </remarks>
Public NotInheritable Class Startup
    Public Shared Sub Main(ByVal args As String())
        Dim wrapper As New SingleInstanceApplicationWrapper()
        wrapper.Run(args)
    End Sub
End Class


''' <summary>
'''     A wrapper for the WPF application class so that the built-in support for single instance apps
'''     that’s provided in Windows Forms can be used with a WPF app.
''' </summary>
''' <seealso cref="ApplicationServices.WindowsFormsApplicationBase" />
Public Class SingleInstanceApplicationWrapper
    Inherits ApplicationServices.WindowsFormsApplicationBase

    Public Sub New()
        ' Enable single-instance mode.
        Me.IsSingleInstance = True
    End Sub


    ''' <summary>
    '''     Allows for code to run when the application starts.
    ''' </summary>
    ''' <param name="eventArgs">
    '''     <see cref="ApplicationServices.StartupEventArgs" />. 
    '''     Contains the command-line arguments of the application and indicates whether the 
    '''     application startup should be cancelled.</param>
    ''' <returns>
    '''     A <see cref="Boolean" /> that indicates if the application should continue starting up.
    ''' </returns>
    Protected Overrides Function OnStartup(ByVal eventArgs As ApplicationServices.StartupEventArgs) As Boolean

        Dim title As String = "Herbert.NET"
        ' Catel initialisation.
#If DEBUG Then
        ' Log all Catel messages to the immediate window.
        LogManager.AddDebugListener()
#End If
        'StyleHelper.CreateStyleForwardersForDefaultStyles()

        ' Instantiate the Herbert application.
        Dim myApp = New App()

        With myApp
            ' Instantiate the main Herbert window.
            Dim myWindow = New MainWindow
            .MainWindow = myWindow

            Dim myTabablzControl As TabablzControl = myWindow.InitialTabablzControl
            Dim myLayout As Layout = myWindow.RootLayout

            '-------------------------------------------------------------------------------------------------
            ' Try to split the TabablzControl.
            ' This fails with  an 'Instance not within any layout' error.
            '-------------------------------------------------------------------------------------------------
            Dim branchResult As BranchResult = Layout.Branch(myTabablzControl, Orientation.Vertical, False, 0.25)
            Dim newTabablzControl As TabablzControl = branchResult.TabablzControl

            ' Display the main window.
            .Run(myWindow)
        End With

        Return False
    End Function


    ''' <summary>
    '''     Prevents a second instance of Herbert.NET from starting by handling the 
    '''     StartupNextInstance event of the Application class.
    ''' </summary>
    ''' <param name="sender">
    '''     The source of the event.
    ''' </param>
    ''' <param name="e">
    '''     The <see cref="ApplicationServices.StartupNextInstanceEventArgs"/> instance containing the event data.
    ''' </param>
    Private Sub Application_StartupNextInstance(ByVal sender As Object,
                                                    ByVal e As ApplicationServices.StartupNextInstanceEventArgs) _
                                                    Handles Me.StartupNextInstance

        'MessageBox.Show("Prevented second instance from starting.")
    End Sub
End Class

