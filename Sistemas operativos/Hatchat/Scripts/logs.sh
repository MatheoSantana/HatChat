
op2=10

while [ $op2 != 0 ]
do
	clear
	echo ""
	echo "   MENU LOGS"
	echo ""
	echo "1- Usuarios logueados"
	echo "2- Intentos fallidos de coneccion"
	echo "3- Ultima coneccion de usuarios"
	echo "0- Volver"
	echo ""
	echo ""

	read -p "Opcion: " op2

	clear

	case $op2 in

	1)
		sh UsuariosLogueados.sh
	;;

	2)
		sh IntentosDeConeccion.sh
	;;

	3)
		sh UltimasConecciones.sh
	;;

	0)
		sh CentroDeComputos.sh
	;;

	esac
done
