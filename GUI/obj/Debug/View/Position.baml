   M S B A M L   `   `   `  ����d  `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF  5      > :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:GUI.ViewGUI.View 5      -clr-namespace:GUI.ConverterGUI.Converter 5         GUI.View.Position   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5      (localclr-namespace:GUI.View     5      1	Converterclr-namespace:GUI.Converter     5        � 	Resources  5      4  .GUI.Converter.GeoCoordinateToLocationConverter $   GeoCoordinateToLocationConverter��%   &	          5   
   65   5       � DataContext 5      �� 5   
    �� Path$ Position�6     Locator �� Source# [ 6"   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��4��6%   ���	#FFB4AAAA.+�5      �� -   5         ��Name$ button��5      $��Zurück��6%   $��Center=�67   $��10q�6T   $��Center=�6a   $��80��6|   ���	#FFD6A1A1��6�   �� *	TourBtn+5      � 5   
   $��1��6   
�������.+�5      �� -   5         ��Name$ label��5      $
��Left=�6#   $��	12,45,0,0q�6>   $	��Top=�6Q   $��16(�6�   $
��Bold"�6�   ��6i   �� *CurrentPositionEntity.Title+6�   �� 5      -   5         ��Name$ 	textBlock��5      $
��Left=�6+   $��
30,106,0,0q�6F   $
��Wrap=�6Z   $	��Top=�6�   $	��179��6�   $	��440��6�   ��6n   �� *#!CurrentPositionEntity.Description+6�   '   !Microsoft.Maps.MapControl.WPF.Map  5      -   5          Name$ myMap��5      $��30,290,10,152q�6#   +   %Microsoft.Maps.MapControl.WPF.MapCore	   	ZoomLevel$	 16Q�6�   
   CredentialsProviderT   NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F
 @AlpCBJ6yUtQwkdXDIunuUgrrSnGc0eNHQZ35UkoEQEGVDEovXbiouJrRlKjyJp8y 6�      Mode;   5Microsoft.Maps.MapControl.WPF.Design.MapModeConverter$
 Road 69     Center 6;   �� *#!CurrentPositionEntity.GPSPosition+ �� 	Converter# [   �� UpdateSourceTrigger$ PropertyChanged=�   Children. 5      +   %Microsoft.Maps.MapControl.WPF.Pushpin     Location 6   �� *#!CurrentPositionEntity.GPSPosition+# [  $ PropertyChanged=�5      �� 5       -   5        $ 
label_Copy��5       $��Beschreibung:��6(   $
��Left=�6@   $��	12,75,0,0q�6[   $	��Top=�6n   �� 5!      -   5        $ label_Copy1��5!      $��Dauer:��6)   $
��Left=�6:   $��251,433,0,0q�6U   $	��Top=�6j   �� 5"      -   5        $ label_Copy8��5"      $
��Left=�6i   $��290,434,0,0q�6�   $	��Top=�6�   ��6)   �� * CurrentPositionEntity.Duration+ �� Mode$ OneWay=�6�   �� 5#      -   5        $ label_Copy2��5#      $
��Von:��6)   $
��Left=�68   $��251,464,0,0q�6S   $	��Top=�6h   �� 5$      -	   5        $ label_Copy3��5$      $
��Left=�6�   $��290,464,0,0q�6�   $	��Top=�6�   ��6)   �� *!CurrentPositionEntity.Startdate+ �� StringFormat$ {0:dd.MM.yyyy HH:mm:ss}��$ OneWay=�6�   �� 5%      -
   5        $ label_Copy4��5%      $
��Bis:��6)   $
��Left=�68   $��251,495,0,0q�6S   $	��Top=�6h   �� 5&      -   5        $ label_Copy5��5&      $
��Left=�6�   $��290,495,0,0q�6�   $	��Top=�6�   ��6)   �� *CurrentPositionEntity.Enddate+$ {0:dd.MM.yyyy HH:mm:ss}��$ OneWay=�6�   �� 5'      -   5        $ label_Copy6��5'      $��Preis in €:��6)   $
��Left=�6?   $��251,526,0,0q�6Z   $	��Top=�6o   �� 5(      -   5        $ label_Copy7��5(      $
��Left=�6X   $��317,526,0,0q�6s   $	��Top=�6�   ��6)   �� *CurrentPositionEntity.Cost+6�   5)      5*      5+      