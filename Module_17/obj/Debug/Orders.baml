   M S B A M L   `   `   `  ����D  @Module_17, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Module_17	Module_17  5   	       Module_17.Orders   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Module_17     5   	     � Title$  Orders��5   	   $	��450��6   $	��800��6%   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid��5      
�������$��0��5   +      AutoGenerateColumns .  $��10q�5   /   ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *id+  5      $ IdOrder��6%    66   �� *	IdOrder+  5      $ ClientId��6%    67   �� *
ClientId+  5      $ 	ProductId��6%    68   �� *	ProductId+5      �� 5   
   
����·�$��Center=�6+   $	��Top=�5      $	��400��6)    �� CornerRadius$ 10��65   $��1��5      $��	0 20 0 0 q�6!   ._�5      �� .+�5      �� $��Order Id��6   $��18(�6,   $
��10 5q�6:   $��Center=�6H   $
��Bold"�6e   �� 5       -   5         ��Name$ Order_id��5       $��18(�6,   $
��10 5q�6:   �� 5!      $��	Client Id��6   $��18(�6-   $
��10 5q�6;   $��Center=�6I   $
��Bold"�6f   �� 5"      -   5        $ 	Client_id��5"      $��18(�6-   $
��10 5q�6;   �� 5#      $��
Product Id��6   $��18(�6.   $
��10 5q�6<   $��Center=�6J   $
��Bold"�6g   �� 5$      -   5        $ 
Product_id��5$      $��18(�6.   $
��10 5q�6<   � 5'      $��52��6    5(      �� 5)      $��* �6+   �� 5*      $��* �6+   .+�5,      �� -   5        $	��Add��5,      $��Center=�6+   $	��100��5-      
�������
���� ��$
��10 5q�5/      6+   �� 50      -   5        $��Delete��50      $��Center=�6.   $��1��51      $	��101��6.   
�������
���� ��$
��10 5q�53   1   6?   54      55      56      57      58      