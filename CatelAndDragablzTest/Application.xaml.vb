Imports System.Windows
Imports Catel.IoC.ServiceLocatorExtensions
Imports Catel.Logging
Imports Catel.Windows

Class Application
    ''' <summary>
    ''' 	Raises the <see cref="E:System.Windows.Application.Startup"/> event.
    ''' </summary>
    ''' <param name="e">A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.</param>
    Protected Overrides Sub OnStartup(e As StartupEventArgs)
#if DEBUG Then
        LogManager.AddDebugListener()
#endif	

        StyleHelper.CreateStyleForwardersForDefaultStyles()

        ' TODO: Using a custom IoC container like Unity? Register it here:
        ' Catel.IoC.ServiceLocator.Instance.RegisterExternalContainer(MyUnityContainer);

        MyBase.OnStartup(e)
    End Sub
End Class