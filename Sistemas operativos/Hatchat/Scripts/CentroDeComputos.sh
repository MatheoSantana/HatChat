op=10
while [ $op != 0 ]
do
	clear
	echo ""
	echo " CENTRO DE COMPUTOS "
	echo ""
	echo "1- ABM-Usuario"
	echo "2- Registro de auditoria"
	echo "3- Respaldo"
	echo "4- Firewall"
	echo "0- Salir"
	echo ""

	read -p "Opcion: " op

	clear

	case $op in

		1)
			sh ABMusuarios.sh

		;;

		2)
			sh logs.sh
		;;

		3)
			sh respaldo.sh
			clear
			echo ""
			echo "Respaldo Satisfactorio"
			echo ""
			sleep 2
		;;

		4)
			sh firewall.sh
		;;

		0)
			exit
		;;
	esac
done
