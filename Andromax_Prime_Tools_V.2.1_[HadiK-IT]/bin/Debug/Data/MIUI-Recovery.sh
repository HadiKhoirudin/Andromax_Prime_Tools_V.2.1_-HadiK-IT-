#!/system/bin/sh
##recovery.sh script installer
Recovery=/sdcard/MIUI-Recovery.img
if test -f "$Recovery"; then
    dd if="$Recovery" of=/dev/block/platform/sdio_emmc/by-name/recovery
	sleep 1
fi
