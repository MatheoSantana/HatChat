
op=10
while [ $op != "0" ]
do
	clear
	echo ""
	echo " FIREWALL"
	echo ""
	echo "1- Activar firewall"
	echo "2- Desactivar firewall"
	echo "3- Verificar configuracion de firewall"
	echo "4- Rescagar configuacion de firewall"
	echo "5- Ver zona predeteminada del firewall"
	echo "6- Cambiar zona pedeterminada del firewall"
	echo "0- Volver"
	echo ""

	read -p "Opcion: " op

	clear

	case $op in
	1)
		sudo systemctl start firewalld
		sudo systemctl enable firewalld

		read -p "" x
	;;

	2)
		sudo systemctl disable firewalld
		sudo systemctl stop firewalld

		read -p "" x
	;;

	3)
		sudo firewall-cmd --state

		read -p "" x
	;;

	4)
		sudo firewall-cmd --reload

		read -p "" x
	;;

	5)
		sudo firewall-cmd --get-default-zone
		
		read -p "" x
	;;

	6)
		read -p "Ingrese nueva zona: " zonita
		sudo firewall-cmd --set-default-zone=$zonita

		read -p "" x
	;;

	0)
		sh CentroDeComputos.sh
	;;

	esac
done
