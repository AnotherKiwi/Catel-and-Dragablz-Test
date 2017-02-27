''' <summary>
'''     Creates the WPF application owning the main Herbert window.
''' </summary>
''' <seealso cref="Windows.Application" />
Public Class App

    Inherits Windows.Application

#Region "Fields"


#End Region ' Fields

#Region "Properties"


#End Region ' Properties

#Region "Event Handlers"

    ''' <summary>
    '''     Handles the application's Startup event.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="StartupEventArgs"/> instance containing the event data.</param>
    Private Sub Application_Startup(ByVal sender As Object,
                                    ByVal e As StartupEventArgs) _
                                    Handles Me.Startup

        ' Some startup code here...
    End Sub




    ''' <summary>
    '''     Handles the application's Exit event.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.ExitEventArgs"/> instance containing the event data.</param>
    Private Sub Application_Exit(ByVal sender As Object,
                                     ByVal e As System.Windows.ExitEventArgs) _
                                     Handles Me.Exit

        ' Some shutdown code here...

    End Sub

#End Region

End Class
