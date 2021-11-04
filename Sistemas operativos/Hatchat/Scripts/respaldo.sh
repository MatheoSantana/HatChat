mysqldump -u root -p Hatchat > respaldoHatchat.sql
fecha="$(date)"
mkdir /home/Hatchat/Respaldos/"$fecha"
rsync respaldoHatchat.sql /home/Hatchat/Respaldos/"$fecha"
