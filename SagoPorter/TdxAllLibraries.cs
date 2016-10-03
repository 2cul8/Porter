/// @file        TdxAllLibraries.cs
/// @copyright   Copyright (c) 2015 Toradex AG
/// $Author:     chitresh.gupta $
/// $Rev:        0000 $ 
/// $Date:       2015-04-23 10:41:41 +0200 (Do, 23 Apr 2015) $
/// @brief       .NET wrapper for Toradex WinCE libraries.\n
///              It allows to use the TdxAllLibraries.dll from a managed .NET application.\n
///              This code is *not* verified. It is provided as is, without maintenance!\n
///              Still any feedback is welcome to improve this code.
/// @test        Colibri VF61 and VF50
/// @target      Colibri T30, T20, VFxx.
///
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

//******************************************************************************
// Imports for TdxCommon.h
class TdxCommon
{
    /// type definition for a software version (usually shown as `[Major].[Minor].[Build]`
    public struct tVersion
    {
        UInt32 Major;           ///< Major Version Number
        UInt32 Minor;           ///< Minor Version Number
        UInt32 Build;           ///< Build Number
    }
    public enum ParamStorageType
    {
        StoreToRegistry = 0,    ///< Store the parameter only temporarily, until the library's DeInit() function is called.
        StoreVolatile = 1       ///< Store the value also in the registry. It will be used as new default when the library's Init() function is called.
    }
}

//******************************************************************************
// Dll Imports for gpio.h functions
class gpio
{
    /// define possible options to specify an IO pin
    public enum tIoType
    {
        ioNone = -1,                  ///< specify that this Io is unused and ignored
        ioReserved = 0x0000,          ///< do not use this undefined usage type (could be GPIO, SODIMM, ...)
        ioGpio = 0x0010,              ///< specify a GPIO
        ioColibriPin = 0x0020,        ///< specify an SODIMM pin of a Colibri module
        ioColibriExtension = 0x0021,  ///< specify a pin on the Colibri FFC Extension connector
        ioApalisPin = 0x0030          ///< specify an MXM3 pin of an Apalis module
    }
    
    /// 32 bit uIo (higher 16 bits - Type of IO, lower 16 bits - IO number)
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct uIo
    {
        [FieldOffset(0)]
        public UInt16 number;
        [FieldOffset(2)]
        public UInt16 type;

        [FieldOffset(0)]
        public tGpio Gpio;

        [FieldOffset(0)]
        public tColibriPin ColibriPin;

        [FieldOffset(0)]
        public tColibriExtensionPin ColibriExtensionPin;

        [FieldOffset(0)]
        public tApalisPin ApalisPin;

        [FieldOffset(0)]
        public UInt32 GenericDefinition;

        public struct tGpio
        {
            public UInt16 nr;
            public UInt16 tp;
        }
        public struct tColibriPin
        {
            public UInt16 nr;
            public UInt16 tp;
        }
        public struct tApalisPin
        {
            public UInt16 nr;
            public UInt16 tp;
        }
        public struct tColibriExtensionPin
        {
            public UInt16 nr;
            public UInt16 tp;
        }
        // Static initializer
        public uIo(UInt16 ioNum, UInt16 ioType) : this()
        { 
            this.number = ioNum;
            this.type = ioType;
        }
    }
    /// Struct to store two IOs.
    /// This is used to describe a multiplexed pin, i.e. two GPIOs shorted to one module pin.
    public struct tTwoIo
    {
        uIo Primary;            ///< For signals that have two SoC GPIOs shorted together, this field describes the primary IO.
                                ///< There is no fixed rule which IO is the primary or secondary, it is just a Toradex definition.\n
                                ///< For regular IOs, this is the only valid entry of the tTwoIo structure.
        uIo Secondary;          ///< For signals that have two SoC GPIOs shorted together, this field describes the secondary IO.\n
                                ///< For regular IOs, this field is invalid.
    }

    /// Alternative function is used in mux and gpio configuration
    public enum tIoAltFn
    {
        ioAltFn0 = 0,           ///< AltFn0 (exact function depends on particular SoC and GPIO)
        ioAltFn1,               ///< AltFn1 (exact function depends on particular SoC and GPIO)
        ioAltFn2,               ///< AltFn2 (exact function depends on particular SoC and GPIO)
        ioAltFn3,               ///< AltFn3 (exact function depends on particular SoC and GPIO)
        ioAltFn4,               ///< AltFn4 (exact function depends on particular SoC and GPIO)
        ioAltFn5,               ///< AltFn5 (exact function depends on particular SoC and GPIO)
        ioAltFn6,               ///< AltFn6 (exact function depends on particular SoC and GPIO)
        ioAltFn7,               ///< AltFn7 (exact function depends on particular SoC and GPIO)
        ioAltFnGpio = -1        ///< Generic definition for the GPIO AltFn, compatible on all modules
    }
    /// Gpio level configuration values
    public enum tIoLevel
    {
        ioLow = 0,              ///< logic low level 
        ioHigh = 1              ///< logic high level
    }
    /// Gpio direction configuration values
    public enum tIoDirection
    {
        ioInput = 0,            ///< direction: input
        ioOutput = 1            ///< direction: output
    }

    [DllImport("TdxAllLibrariesDll.dll")]                           ///< Importing DLL
    public static extern IntPtr Gpio_Init(string registryPath);     ///< External function declaration

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Gpio_Deinit(IntPtr hGpio);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Gpio_Open(IntPtr hGpio);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Gpio_Close(IntPtr hGpio);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern gpio.tIoDirection Gpio_GetDir(IntPtr hGpio, gpio.uIo io);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void Gpio_SetDir(IntPtr hGpio, gpio.uIo io, gpio.tIoDirection dirOut);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern gpio.tIoLevel Gpio_GetLevel(IntPtr hGpio, gpio.uIo io);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void Gpio_SetLevel(IntPtr hGpio, gpio.uIo io, gpio.tIoLevel val);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void Gpio_ConfigureAsGpio(IntPtr hGpio, gpio.uIo io);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern gpio.uIo Gpio_NormalizeIo(gpio.uIo io);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Gpio_SetConfigString(IntPtr hGpio, gpio.uIo io, string paramName2, string value, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 Gpio_GetConfigString(IntPtr hGpio, gpio.uIo io, string paramName2, string pValue, Int32 maxBytes);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 Gpio_GetConfigInt(IntPtr hGpio, gpio.uIo io, string paramName2, IntPtr pValue);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void Gpio_GetVersion(ref TdxCommon.tVersion ver);
}

//******************************************************************************
// Dll Imports for gpio_vyb.h functions
class gpio_vyb
{

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern IntPtr VybGpio_Init(string registryPath);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybGpio_Deinit(IntPtr hGpio);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybGpio_Open(IntPtr hGpio);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybGpio_Close(IntPtr hGpio);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern gpio.tIoDirection VybGpio_GetDir(IntPtr hGpio, gpio.uIo io);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void VybGpio_SetDir(IntPtr hGpio, gpio.uIo io, gpio.tIoDirection dirOut);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern gpio.tIoLevel VybGpio_GetLevel(IntPtr hGpio, gpio.uIo io);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void VybGpio_SetLevel(IntPtr hGpio, gpio.uIo io, gpio.tIoLevel val);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void VybGpio_ConfigureAsGpio(IntPtr hGpio, gpio.uIo io);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern gpio.uIo VybGpio_NormalizeIo(gpio.uIo io);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybGpio_SetConfigString(IntPtr hGpio, gpio.uIo io, string paramName2, string value, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybGpio_GetConfigString(IntPtr hGpio, gpio.uIo io, string paramName2, string pValue, UInt32 maxBytes);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybGpio_GetConfigInt(IntPtr hGpio, gpio.uIo io, string paramName2, IntPtr pValue);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void VybGpio_GetVersion(ref TdxCommon.tVersion ver);
}

//******************************************************************************
// Dll Imports for adc.h functions
class adc
{

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern IntPtr Adc_Init(string portName);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Adc_Deinit(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Adc_Open(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Adc_Close(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 Adc_Read(IntPtr hPort, IntPtr microVolts, UInt32 maxBytes);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 Adc_GetConfigInt(IntPtr hPort, string paramName, IntPtr pValue);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Adc_SetConfigInt(IntPtr hPort, string paramName, UInt32 pValue, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void Adc_GetVersion(ref TdxCommon.tVersion ver);
}

//******************************************************************************
// Dll Imports for adc_vyb.h functions
class adc_vyb
{
    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern IntPtr VybAdc_Init(string portName);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybAdc_Deinit(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybAdc_Open(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybAdc_Close(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybAdc_Read(IntPtr hPort, IntPtr microVolts, UInt32 maxBytes);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybAdc_GetConfigInt(IntPtr hPort, string paramName, IntPtr pValue);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybAdc_SetConfigInt(IntPtr hPort, string paramName, UInt32 pValue, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void VybAdc_GetVersion(ref TdxCommon.tVersion ver);
}

//******************************************************************************
// Dll Imports for spi.h functions
class spi
{
    public enum eSpiMasterSlave
    {
        SpiMaster,             ///< Configure as Master Device
        SpiSlave               ///< Configure as Slave Device
    }

    public enum eSpiMode
    {
        SpiMode0,              ///< Mode 0 - Polarity (CPOL) 0, Phase (CPHA) 0
        SpiMode1,              ///< Mode 1 - Polarity (CPOL) 0, Phase (CPHA) 1
        SpiMode2,              ///< Mode 2 - Polarity (CPOL) 1, Phase (CPHA) 0
        SpiMode3               ///< Mode 3 - Polarity (CPOL) 1, Phase (CPHA) 1
    }

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern IntPtr Spi_Init(string portName);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Spi_Deinit(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Spi_Open(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Spi_Close(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 Spi_Read(IntPtr hPort, IntPtr pbuf, UInt32 numberOfFrames);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 Spi_Write(IntPtr hPort, IntPtr pbuf, UInt32 numberOfFrames);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 Spi_ReadWrite(IntPtr hPort, IntPtr rxBuffer, IntPtr txBuffer, UInt32 numberOfFrames);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Spi_SetConfigString(IntPtr hPort, string paramName, string value, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Spi_SetConfigInt(IntPtr hPort, string paramName, UInt32 pValue, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 Spi_GetConfigString(IntPtr hPort, string paramName, string pValue, UInt32 maxBytes);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 Spi_GetConfigInt(IntPtr hPort, string paramName, IntPtr pValue);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void Spi_GetVersion(ref TdxCommon.tVersion ver);
}

//******************************************************************************
// Dll Imports for sp_vyb.h functions
class spi_vyb
{
    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern IntPtr VybSpi_Init(string portName);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybSpi_Deinit(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybSpi_Open(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybSpi_Close(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybSpi_Read(IntPtr hPort, IntPtr pbuf, UInt32 numberOfFrames);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybSpi_Write(IntPtr hPort, IntPtr pbuf, UInt32 numberOfFrames);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybSpi_ReadWrite(IntPtr hPort, IntPtr rxBuffer, IntPtr txBuffer, UInt32 numberOfFrames);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybSpi_SetConfigString(IntPtr hPort, string paramName, string value, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybSpi_SetConfigInt(IntPtr hPort, string paramName, UInt32 pValue, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybSpi_GetConfigString(IntPtr hPort, string paramName, string pValue, UInt32 maxBytes);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybSpi_GetConfigInt(IntPtr hPort, string paramName, IntPtr pValue);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void VybSpi_GetVersion(ref TdxCommon.tVersion ver);
}

//******************************************************************************
// Dll Imports for pwm.h functions
class pwm
{
    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern IntPtr Pwm_Init(string portName);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Pwm_Deinit(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Pwm_Open(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Pwm_Close(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 Pwm_GetConfigString(IntPtr hPort, string paramName, string pValue, UInt32 maxBytes);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Pwm_SetConfigString(IntPtr hPort, string paramName, string value, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 Pwm_GetConfigInt(IntPtr hPort, string paramName, IntPtr pValue);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Pwm_SetConfigInt(IntPtr hPort, string paramName, UInt32 value, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void Pwm_GetVersion(ref TdxCommon.tVersion ver);
}

//******************************************************************************
// Dll Imports for pwm_vyb.h functions
class pwm_vyb
{
    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern IntPtr VybPwm_Init(string portName);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybPwm_Deinit(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybPwm_Open(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybPwm_Close(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybPwm_GetConfigString(IntPtr hPort, string paramName, string pValue, UInt32 maxBytes);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybPwm_SetConfigString(IntPtr hPort, string paramName, string value, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybPwm_GetConfigInt(IntPtr hPort, string paramName, IntPtr pValue);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybPwm_SetConfigInt(IntPtr hPort, string paramName, UInt32 value, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void VybPwm_GetVersion(ref TdxCommon.tVersion ver);
}

//******************************************************************************
// Dll Imports for i2c.h functions
class i2c
{
    const UInt32 I2C_RW_FAILURE = UInt32.MaxValue;

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern IntPtr I2c_Init(string portName);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool I2c_Deinit(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool I2c_Open(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool I2c_Close(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 I2c_Read(IntPtr hPort, IntPtr pbuf, UInt32 numberOfFrames);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 I2c_Write(IntPtr hPort, IntPtr pbuf, UInt32 numberOfFrames);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 I2c_GetConfigInt(IntPtr hPort, string paramName, IntPtr pValue);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool I2c_SetConfigInt(IntPtr hPort, string paramName, UInt32 value, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void I2c_GetVersion(ref TdxCommon.tVersion ver);
}

//******************************************************************************
// Dll Imports for i2c_vyb.h functions
class i2c_vyb
{
    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern IntPtr VybI2c_Init(string portName);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybI2c_Deinit(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybI2c_Open(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybI2c_Close(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybI2c_Read(IntPtr hPort, IntPtr pbuf, UInt32 numberOfFrames);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybI2c_Write(IntPtr hPort, IntPtr pbuf, UInt32 numberOfFrames);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybI2c_GetConfigInt(IntPtr hPort, string paramName, IntPtr pValue);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybI2c_SetConfigInt(IntPtr hPort, string paramName, UInt32 value, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void VybI2c_GetVersion(ref TdxCommon.tVersion ver);
}

//******************************************************************************
// Dll Imports for can.h functions
class can
{
    /// Defines options for frame type
    public enum tCanFrame
    {
        canData = 0,       ///< Data Frame
        canRemote          ///< Remote Frame
    }

    /// Structure of buffer to be used in CAN Read and Write operation 
    public struct tCanBuf
    {
        UInt32    id;      ///< message ID (11/29 bit ID depending upon L"FrameFormat" config value)
        tCanFrame frame;   ///< data or remote frame (canRemote/canData)
        IntPtr    data;    ///< pointer to data (read/write)
    }

    const UInt32 CAN_RW_FAILURE = UInt32.MaxValue;

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern IntPtr Can_Init(string portName);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Can_Deinit(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Can_Open(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Can_Close(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 Can_Read(IntPtr hPort, IntPtr pCanBuf, UInt32 numberOfFrames);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 Can_Write(IntPtr hPort, IntPtr pCanBuf, UInt32 numberOfFrames);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 Can_GetConfigInt(IntPtr hPort, string paramName, IntPtr pValue);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Can_SetConfigInt(IntPtr hPort, string paramName, UInt32 value, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 Can_GetConfigString(IntPtr hPort, string paramName, string pValue, UInt32 maxBytes);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool Can_SetConfigString(IntPtr hPort, string paramName, string pValue, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void Can_GetVersion(ref TdxCommon.tVersion ver);
}

//******************************************************************************
// Dll Imports for can_vyb.h functions
class can_vyb
{
    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern IntPtr VybCan_Init(string portName);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybCan_Deinit(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybCan_Open(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybCan_Close(IntPtr hPort);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybCan_Read(IntPtr hPort, IntPtr pCanBuf, UInt32 numberOfFrames);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybCan_Write(IntPtr hPort, IntPtr pCanBuf, UInt32 numberOfFrames);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybCan_GetConfigInt(IntPtr hPort, string paramName, IntPtr pValue);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybCan_SetConfigInt(IntPtr hPort, string paramName, UInt32 value, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern UInt32 VybCan_GetConfigString(IntPtr hPort, string paramName, string pValue, UInt32 maxBytes);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern bool VybCan_SetConfigString(IntPtr hPort, string paramName, string pValue, TdxCommon.ParamStorageType storageType);

    [DllImport("TdxAllLibrariesDll.dll")]
    public static extern void VybCan_GetVersion(ref TdxCommon.tVersion ver);
}

