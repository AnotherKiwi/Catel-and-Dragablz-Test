Imports Dragablz
Imports CatelAndDragablzTest.Views

Namespace Helpers

    ''' <summary>
    '''     Class that enables a custom Tab Host window to be created
    '''     when a tab is torn off a <see cref="TabablzControl"/>.
    ''' </summary>
    ''' <seealso cref="IInterTabClient" />
    Public Class MainWindowInterTabClient

        Implements IInterTabClient

        ''' <summary>
        '''     Provide a new Tab Host window so a tab can be torn from an existing window into a new window.
        ''' </summary>
        ''' <param name="interTabClient"></param>
        ''' <param name="partition">Provides the partition where the drag operation was initiated.</param>
        ''' <param name="source">The source control where a dragging operation was initiated.</param>
        ''' <returns></returns>
        Public Function GetNewHost(interTabClient As IInterTabClient,
                                   partition As Object,
                                   source As TabablzControl) As INewTabHost(Of Window) Implements IInterTabClient.GetNewHost

            ' Following modelled on DragablzDemo BoundExampleInterTabClient()
            Dim view As New MainWindow

            Return New NewTabHost(Of Window)(view, view.InitialTabablzControl)

        End Function


        ''' <summary>
        '''     Called when a tab has been emptied, and thus typically a window needs closing.
        ''' </summary>
        ''' <param name="tabControl"></param>
        ''' <param name="window"></param>
        ''' <returns></returns>
        Public Function TabEmptiedHandler(tabControl As TabablzControl,
                                      window As Window) As TabEmptiedResponse Implements IInterTabClient.TabEmptiedHandler
            'MessageBox.Show($"Trying to empty {tabControl.Name}")
            Return TabEmptiedResponse.CloseWindowOrLayoutBranch
        End Function

    End Class

End Namespace

