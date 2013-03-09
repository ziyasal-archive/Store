1- Bir lement bind edilmiş property için IErrorDataInfo imp var ise 
	- <Setter Property="Validation.ErrorTemplate">  target -> TextBox  
	- Bindin tanımlaması yaparken bunları tanımlıyoruz. ValidatesOnDataErrors=True, NotifyOnValidationError=True, UpdateSourceTrigger=PropertyChanged
	- TextBox a style'ını bildiriyoruz ->  Style="{StaticResource valStyle}"

2- Data Triggers ve Stysle Setters

<Window.Style>
<Style TargetType="{x:Type Window}">
	<Style.Triggers>
		<DataTrigger Binding="{Binding Mode}">
			<DataTrigger.Value>
				<ViewModel:Mode>Add</ViewModel:Mode>
			</DataTrigger.Value>
			<Setter Property="Title" Value="Add Order"/>
		</DataTrigger>
		<DataTrigger Binding="{Binding Mode}">
			<DataTrigger.Value>
				<ViewModel:Mode>Edit</ViewModel:Mode>
			</DataTrigger.Value>
			<Setter Property="Title" Value="Edit Order"/>
		</DataTrigger>
	</Style.Triggers>
</Style>
</Window.Style>

3- MultiData Trigger ve conditions
 <MultiDataTrigger>
	<MultiDataTrigger.Conditions>
		<Condition Binding="{Binding ElementName=txtQuantity, Path=(Validation.HasError)}" Value="false"/>
		<Condition Binding="{Binding ElementName=txtDescription, Path=(Validation.HasError)}" Value="false"/>
	</MultiDataTrigger.Conditions>
	<Setter Property="IsEnabled" Value="True"/>
</MultiDataTrigger>