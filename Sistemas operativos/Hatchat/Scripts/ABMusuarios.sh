clear
if [ $USER = "root" ]
then
	op1=10
	while [ $op1 != 0 ]
	do
		clear
		echo ""
		echo "    MENU PRINCIPAL"
		echo ""
		echo "1- Agregar Usuarios"
		echo "2- Eliminar Usuarios"
		echo "3- Gestionar Contraseña"
		echo "4- Crear Grupo"
		echo "5- Eliminar Grupo"
		echo "6- Agregar Usuario a un Grupo"
		echo "7- Eliminar Usuario de un grupo"
		echo "0- Volver"
		echo ""

		read -p "Opcion: " op1

		clear

		case $op1 in

		1)
			echo ""
			echo "    AGREGAR USUARIO"
			echo ""
			read -p "Ingrese nombre de Usuario: " usuario
			useradd -m $usuario
			echo ""
			echo "USUARIO CREADO"
			sleep 1

		;;

		2)
			echo ""
			echo "    ELIMINAR USUARIO"
			echo ""
			read -p "Ingrese nombre de Usuario: " usuario
			userdel -r $usuario
			echo ""
			echo "USUARIO ELIMINADO"
			sleep 1
		;;

		3)
			echo ""
			echo "    GESTIONAR CONTRASEÑA"
			echo ""
			opU=10
			echo "1- Cambiar contraseña"
			echo "2- Eliminar contraseña"
			echo "0- Volver"
			echo ""
			read -p "Opcion: " opU

			case $opU in

			1)
				clear
				echo ""
				echo "  CAMBIAR CONTASEÑA"
				echo ""
				read -p "Ingrese nombre de Usuario: " usuario
				echo ""
				echo "Ingrese contraseña:"
				passwd --stdin $usuario
				echo ""
				echo "CONTRASEÑA CAMBIADA"
				sleep 2
			;;

			2)
				clear
				echo ""
				echo "  ELIMINAR CONTRASEÑA"
				echo ""
				read -p "Ingresar nombre de Usuario: " usuario
				passwd -d $usuario
				echo ""
				echo "CONTRASEÑA ELIMINADA"
				sleep 2
			;;

			esac

		;;

		4)
			clear
			echo ""
			echo "   CREAR GRUPO"
			echo ""
			read -p "Ingrese nombre del grupo: " grupo
			groupadd $grupo
			echo ""
			echo "GRUPO CREADO"
			sleep 2
		;;

		5)
			clear
			echo ""
			echo "  ELIMINAR GRUPO"
			echo ""
			read -p "Ingrese nombre del grupo: " grupo
			groupdel $grupo
			echo ""
			echo "GRUPO ELIMINADO"
			sleep 2
		;;

		6)
			clear
			echo ""
			echo "AGREGAR USUARIO A UN GRUPO"
			echo ""
			read -p "Nombre de Usuario: " usaurio
			read -p "Nombre de Grupo" grupo
			usermod -G $grupo $usaurio
			echo ""
			echo ""
			echo "USUARIO AGREGADO"
			sleep 1
		;;

		7)
			clear
			echo ""
			echo "ELIMINAR USUARIO DE UN GRUPO"
			echo ""
			read -p "Nombre de Usuario: " usuario
			read -p "Nombre de Grupo: " grupo
			gpasswd -d $grupo $usuario
			echo ""
			echo "USUARIO ELIMINADO"
			sleep 1
		;;

		0)
			clear
			sh CentroDeComputos.sh

		;;

		esac
	done
else
	echo "Usted no es Usuario root."
	sleep 2
fi

