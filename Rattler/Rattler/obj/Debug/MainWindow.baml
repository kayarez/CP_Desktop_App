   M S B A M L   `   `   `  ����B  >Rattler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RattlerRattler  5   	       Rattler.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Rattler     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Icon$  Resources\Train.jpg��5   	   $	��600��5	      $
��1080��6'   
�����_� � 
ResizeMode$ NoResize=�6L    � WindowStartupLocation$ CenterScreen=�6d   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��440��6   �� 5      $	��440��6   �� 5      $	��200��6    � RowDefinitions 5   
   �� 5      $��60��6   �� 5      $��20��6   �� 5      $��40��6   �� 5      $��40��6   �� 5      �� 5      $��40��6   �� 5      .+�5   
   �� $��0��6   $��0��6"   $��3��62   .+�5      �� $
��Bold"�6   $��Rattler��6&   $��30(�68   $��Center=�6F   5      �� 5   
   $��1��6   $��0��6!   $'��!Пункт отправления��61   �� 5   
   $��1��6   $��1��6!   $!��Пункт прибытия��61   �� 5   
   -   5         ��Name$! SearchPlaceDepartureTextBox��5      $��2��67   $��0��6D   $��20(�6T   6d   �� 5   
   -   5        $ SearchPlaceArrivalTextBox��5      $��2��65   $��1��6B   $��20(�6R   6b   �� 5    
   $��2��6   $��3��6"   $��
10,00,10,0q�62   .+�5!   
   �� -   5        $��
Поиск��5!   ,   6>   5"      �� 5#   
   $��3��6   $��0��6   $��3��6-   $��Рейсы:��6A   $��20(�6R   6b   �� 5$   
   $��4��6   $��0��6$   $��2��64   .��5%   
   &   System.Windows.Controls.DataGrid  -   5          Name$ tripDataGrid��5%      $��4��6*   $��0��67   $��2��6G      AutoGenerateColumns .     CanUserAddRows .  	   RowStyle	 5&      �� 5'      
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
  6   .�5(      -   5        5)         Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$' !Пункт отправления��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6j      
IsReadOnly .    CanUserSort .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   ��  �� Path$ PlaceDeparture�6�     5-      $! Пункт прибытия��6%   $ * 6f    .  .   6=   �� $ PlaceArrival�6�     5.      $% Дата отправления��6%   $ * 6h    .  6?   �� $ DateDeparture�6�     5/      $ Дата прибытия��6%   $ * 6d    .  6<   �� $ DateArrival�6�     50      $  Цена билета, р.��6%   $ * 6^    .  6>   �� $
 Cost�6|     51      $  Кол-во билетов��6%   $ * 6c    .  .   6=   �� $ NumberSeats�6�   53      54      �� 55   
   $��5��6   $��0��6   $��2��6-   $��Корзина:��6A   $��20(�6T   6d   �� 56   
   $��6��6   $��0��6$   $��2��64   .��57   
     -   5        $ BasketDataGrid��57       .  	 58      �� 59      "
  6   .�5:      -   5        5;       5=        5>      -   5        DateDeparture��$' !Пункт отправления��5>   <   $ * 6�    .  6W   �� $ PlaceDeparture�6�     5?      $! Пункт прибытия��6%   $ * 6f    .  6=   �� $ PlaceArrival�6�     5@      $% Дата отправления��6%   $ * 6h    .  6?   �� $ DateDeparture�6�     5A      $ Дата прибытия��6%   $ * 6d    .  6<   �� $ DateArrival�6�     5B      $  Цена билета, р.��6%   $ * 6^    .  6>   �� $
 Cost�6|     5C      $  Кол-во билетов��6%   $ * 6e    .  6=   �� $ NumberSeats�6�   5E      5F      �� 5G   
   $��2��6   $��6��6%   $��10,10,10,10q�62   .+�5H      �� -	   5         ��Name$ Order��5H      $��Заказать��6$   $��30��67   6C   5I      5J      5K      