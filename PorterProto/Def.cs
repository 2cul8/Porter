using System;
using System.Collections.Generic; 
using System.Text;

namespace PorterProto
{
    public static class ProtoInfo
    {
        public const string Version = "0.1.110716";
    }

    public enum Tasks : byte
    {
        TASK_SEND = 0,
        TASK_MSG_PLC = 1,
        TASK_SPEC_PLC = 2,
        TASK_QUOTE = 3,
        TASK_IMPUL = 4,
        TASK_INSEG = 5,
        TASK_INPUT = 6,
        TASK_OUTPUT = 7,
        TASK_MEMIF = 8,
        TASK_MEMUF = 9,
        TASK_TIMER = 10,
        TASK_MONOS = 11,
        TASK_CONTA = 12,
        TASK_SETRSET = 13,
        TASK_VERSIONE = 14,
        TASK_STATO_DSA = 15,
        TASK_CHKSUM = 16,
        TASK_VAR_PLC = 17,
        TASK_VAR_QUO = 18,
        TASK_MAPPATURA = 19,
        TASK_READ_ADC = 20,
        FILLER1 = 21,
        FILLER2 = 22,
    }

    internal enum TaskTags : byte
    {
        TAG_IDLE = 0,
        TAG_SEND = 1,
        TAG_CNT_PLC = 65,  //'A',    // Contatore PLC
        TAG_MSG_PLC = 71,  //'G',    // Messaggi PLC
        TAG_SPEC_PLC = 77, //'M',	// Memorie speciali PLC
        TAG_QUOTE = 81,    //'Q',	// Quote in unità di misura
        TAG_IMPUL = 108,   //'l',	// Quote in impulsi
        TAG_INSEG = 74,    //'J',    // Inseguimento
        TAG_INPUT = 73,    //'I',	// Ingressi
        TAG_OUTPUT = 85,   //'U',    // Output
        TAG_MEMIF = 78,    //'N', 	// Memorie PLC IF
        TAG_MEMUF = 82,    //'R',	// Memorie PLC UF
        TAG_TIMER = 84,    //'T',	// Timer
        TAG_MONOS = 90,    //'Z',	// Monostabili
        TAG_CONTA = 88,    //'X', 	// Contatori PLC
        TAG_SETRSET = 89,  //'Y',	// Set-Reset
        TAG_VERSIONE = 86, //'V',    // Versione
        TAG_STATO_DSA = 69,//'E',    // Stato DSA
        TAG_CHKSUM = 68,   //'D',    // Cecksum parametri
        TAG_VAR_PLC = 105, //'i', 	// Variabili PLC
        TAG_VAR_QUO = 109, //'m',	// Variabili QUOTE
        TAG_MAPPATURA = 66,//'B',    // Valori di mappatura
        TAG_READ_ADC = 72, //'H',	// Lettura ADC 
        TAG_GET_PAR = 76,  //'L',	// Lettura parametri
        TAG_SHREG = 97,    //'a',	// Shift Register
        TAG_GET_PLC = 99,  //'c',	// Ricevi PLC da DSA
        TAG_GET_STRU = 101,//'e',	// Ricevi struttura dati
        TAG_GET_AUTO = 102,//'f',	// Ricevi automatico
        // Trasmissione ---------------------------------------------------------------------------
        TAG_CICLO = 70,    //'F',	// Invia ciclo 'F'
        TAG_STRU = 87,     //'W',    // Invia struttura
        TAG_PVM = 80,      //'P',	// Invia i PVM
        TAG_CHAR = 106,    // 'j',	// Invia un carattere
        TAG_SETOUT = 79   // 'O',   // Setta le uscite.
    }
}
