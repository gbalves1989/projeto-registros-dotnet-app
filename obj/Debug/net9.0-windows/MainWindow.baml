   M S B A M L   `   `   `  ����S  ORegistrosEntradaSaidaAPP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:RegistrosEntradaSaidaAPPRegistrosEntradaSaidaAPP  5   	   )    #RegistrosEntradaSaidaAPP.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:RegistrosEntradaSaidaAPP     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$#  Registros de Entrada e Saída��5	   	   $	��700��6.   $
��1000��6;    � WindowStartupLocation$ CenterScreen=�5
   	      MaterialDesignWindow#��[  5   	    � WindowState$ 	Maximized=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      )  #MaterialDesignThemes.Wpf.DrawerHost     IsLeftDrawerOpen 6    ��  �� ElementName$ MenuToggleButton�� �� Path$ 	IsChecked�   LeftDrawerContent 5   
   �� 5      $��16q�6   .+�5      ��  $  MaterialDesignHeadline5TextBlock#��[ 6   $��0 0 0 16q�6V   Menu6n   �� 5      -   5          MaterialDesignFlatButton#��[ 5      $��0 8 0 0q�5         CloseDrawerCommand#��Z 5      .��5      �� 	 �� Orientation$	 
Horizontal=�6!   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$

 Home=�62   $��Center=�6>   $��0 0 8 0q�6Y   �� 5      $
��Home��6$   5      5      9� 5      $��Empresas��6   $��0 8 0 0q�5        MaterialDesignExpander#��[ 5       .��5!      �� $��24 0 0 0q�6!   .+�5"      �� -   5        #��[ 5"   !   $��0 4 0 0q�5#   !   #��Z 5$   !   .��5&      �� $	 
Horizontal=�6)   .+�5'   "     $	
 Add=�6:   $��Center=�6E   $��0 0 8 0q�6`   �� 5(   "   $��Cadastro��6,   5)      5*      �� 5+      -   5        #��[ 5+   !   $��0 4 0 0q�5,   !   #��Z 5-   !   .��5/      �� $	 
Horizontal=�6)   .+�50   "     $
 ViewList=�6:   $��Center=�6J   $��0 0 8 0q�6e   �� 51   "   $��Listar��6,   52      53      54      55      9� 57      $��	Veículos��6   $��0 8 0 0q�58      #��[ 59      .��5:      �� $��24 0 0 0q�6!   .+�5;      �� -   5        #��[ 5;   !   $��0 4 0 0q�5<   !   #��Z 5=   !   .��5?      �� $	 
Horizontal=�6)   .+�5@   "     $	
 Add=�6:   $��Center=�6E   $��0 0 8 0q�6`   �� 5A   "   $��Cadastro��6,   5B      5C      �� 5E      -   5        #��[ 5E   !   $��0 4 0 0q�5F   !   #��Z 5G   !   .��5I      �� $	 
Horizontal=�6)   .+�5J   "     $
 ViewList=�6:   $��Center=�6J   $��0 0 8 0q�6e   �� 5K   "   $��Listar��6,   5L      5M      5N      5O      9� 5Q      $��
Motoristas��6   $��0 8 0 0q�5R      #��[ 5S      .��5T      �� $��24 0 0 0q�6!   .+�5U      �� -   5        #��[ 5U   !   $��0 4 0 0q�5V   !   #��Z 5W   !   .��5Y      �� $	 
Horizontal=�6)   .+�5Z   "     $	
 Add=�6:   $��Center=�6E   $��0 0 8 0q�6`   �� 5[   "   $��Cadastro��6,   5\      5]      �� 5_      -   5        #��[ 5_   !   $��0 4 0 0q�5`   !   #��Z 5a   !   .��5c      �� $	 
Horizontal=�6)   .+�5d   "     $
 ViewList=�6:   $��Center=�6J   $��0 0 8 0q�6e   �� 5e   "   $��Listar��6,   5f      5g      5h      5i      5j      .��5m   
   �  � RowDefinitions 5n      �� 5o      $
��Auto �6    �� 5p      $��* �6    .+�5s      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ 
PrimaryMid=�6'   $��16q�69   .��5t      �  � ColumnDefinitions 5u      �� 5v      $
��Auto �6+   �� 5w      $��* �6+   .+�5y      d� -   5         d�Name$ MenuToggleButton��5z   #    ' #MaterialDesignHamburgerToggleButton#��[ 5y   #    d� 	IsChecked$ FalseY�6`   5z   #   �� 5{      $��1��6    #��[ 60   $��Center=�5|       $��Center=�6;   )'Sistema de Registro de Entrada e Saída5~      5      5�       � 5�      -	   5          �Name$ 	MainFrame��5�   !   $��1��6     � NavigationUIVisibility$ Hidden=�64   5�      5�      5�      