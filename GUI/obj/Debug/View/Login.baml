   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:GUI.ViewGUI.View  5          GUI.View.Login   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:GUI.View     5        � DataContext  5	      ��    Locator �� Source# [   �� Path$ Login�.��5
      � ���	#FFB4AAAA.+�5   
   �� -   5         ��Name$ label��5      $��Benutzername:��6   $
��Left=�67   $��140,184,0,0q�6R   $	��Top=�6g   �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $��25��6>   $��140,215,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $	��Top=�6�   $	��300��6�   ��6s   �� *
Username+6�   �� 5   
   -   5        $ label1��5      $��	Passwort:��6    $
��Left=�64   $��140,255,0,0q�6O   $	��Top=�6d   G� 5   
   -   5         G�Name$ passwort��5      $
��Left=�6(   $��25��6C   $��140,286,0,0q�6O   $	��Top=�6d   $	��300��6|   �� 5   
   -   5         ��Name$ checkBox��5      $��Angemeldet bleiben��6%   $
��Left=�6B   $��220,325,0,0q�6]   $	��Top=�6r    d� 	IsChecked 6�   �� *AngemeldetBleiben+�� 5   
   -   5        	 ��Name$	 button��5      $��Anmelden��6!   $
��Left=�64   $��245,355,0,0q�6O   $	��Top=�6d   $��75��6|   
 �� 	IsDefault
 . ���	#FFD6A1A1��6�   �� *
LoginBtn+��6�   ��  �� ElementName$ passwort��6�   �� 5   
   -   5        $ label2��5      $
��Left=�6    $��140,395,0,0q�6;   $	��Top=�6P   ���	#FFB94F4F��6h   �� *StatusMessage+6�   5      5      