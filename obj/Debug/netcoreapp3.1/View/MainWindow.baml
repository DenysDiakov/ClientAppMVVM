   M S B A M L   `   `   `  ����H  DClientAppMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ClientAppMVVMClientAppMVVM  5   	   A%clr-namespace:ClientAppMVVM.ViewModelClientAppMVVM.ViewModel  5   	   #    ClientAppMVVM.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ClientAppMVVM     5   	   ;	viewmodel%clr-namespace:ClientAppMVVM.ViewModel     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � DataContext 5      2  ,ClientAppMVVM.ViewModel.ApplicationViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��253* �6   �� 5      $��3* �6   �� 5      $
��179* �6   .+�5   
   �� -   5         ��Name$ ReloadButton��5      $��Reload��6I   $��Center=�6Z   $��0,23,0,0q�6w   $	��Top=�6�    J� RenderTransformOrigin$ -2.65,0.904&�6�   ��6'   �� *ReloadCommand+6�   �� 5   
   -   5         ��Name$ AllProductsDataGrid��5      $��36,96,526,88q�6/   $��3��6F   $��0��6W   ��6g   �� *
Products+ �� SelectedItem 5      �� *SelectedProduct+ �� Mode$ TwoWay=���5      �� 5      .R�5      �� $��5q�6!   .+�5      �� $��18(�6$   ��62   ��  �� Path$ Id��� 5       ��6$   �� $
 Name��� 5!      ��6$   �� $ Price�5"      5#      5%      �� 5(   
   -   5        	 ��Name$	 ShoppingCartLabel��5(      $��Your shopping cart��6+   $
��Left=�6H   $��
527,73,0,0q�6c   $	��Top=�6w   $	��176��6�   �� 5*   
   -   5        $ AddToCartButton��5*      $��Add to cart��6I   $
��Left=�6_   $��465,116,0,0q�6z   $	��Top=�6�   $��2��6�   ��6*   �� *
AddCommand+6�   �� 5,   
   -   5        $	 SumLabel��5,      $
��Left=�6:   $��
723,64,0,0q�6U   $��2��6i   $	��Top=�6v   ��6"   �� *Sum+6v   �� 5.   
   -   5        $ CartDataGrid��5.      $��465,101,0,84q�6(   $
��Left=�6?   $	��238��6Z   $��3��6f   ��6w   �� *CartProducts+ 5/      �� *SelectedProduct+$ TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=���50      �� 51      .R�52      �� $��5q�6!   .+�53      �� $��18(�6$   ��62   �� $ Id��� 54      ��6$   �� $
 Name��� 55      ��6$   �� $ Price�56      57      59      �� 5<   
   -   5        $	 AllProductsLabel��5<      $��All products��6*   $
��Left=�6A   $��
106,65,0,0q�6\   $	��Top=�6p   �� 5>   
   -   5        $ DeleteButton��5>      $��Remove from cart��6I   $
��Left=�6d   $��584,116,0,0q�6   $��2��6�   $	��Top=�6�   $	��105��6�   ��6'   �� *DeleteCommand+6�   5B      5D      