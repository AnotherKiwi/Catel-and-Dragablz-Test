Imports Dragablz

Namespace Helpers

    ''' <summary>
    '''     Class that provides a factory method for new <see cref="TabablzControl"/>  tab items.
    ''' </summary>
    Public Class NewTabItem

        ''' <summary>
        '''     Gets the factory method that creates a new <see cref="TabablzControl"/> tab item.
        ''' </summary>
        ''' <value>
        '''     <see cref="Func(Of HeaderedItemViewModel)"/> 
        '''     The factory method that creates a new <see cref="TabablzControl"/> tab item.
        ''' </value>
        ''' <remarks>
        '''     Called when the user clicks the default TabablzControl add button.
        ''' </remarks>
        Public Shared ReadOnly Property Factory() As Func(Of HeaderedItemViewModel)
            Get
                Return Function()
                           Return New HeaderedItemViewModel() With {.Header = DateTime.Now.ToLongTimeString,
                                                                    .Content = "Added by factory method"}
                       End Function
            End Get
        End Property
    End Class

End Namespace