using System;
using System.Windows.Forms;
using NationalInstruments.Visa;

namespace PM2gui
{
    class Tek
    {

        MessageBasedSession mbSession;

        public string TekQuery(MessageBasedSession mbSession, string scpiQuery)
        {
            string result;
            try
            {
                mbSession.RawIO.Write(scpiQuery);
                result = mbSession.RawIO.ReadString();
            }
            catch (Exception exp)
            {
                result = "";
                MessageBox.Show(exp.Message);
            }

            return result;
        }
        
        public void tekWrite(MessageBasedSession mbSession, string scpiWrite)
        {
            try
            {
                mbSession.RawIO.Write(scpiWrite);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                throw;
            }

        }

        public void initTekSettings()
        {
            //view
            mbSession.RawIO.Write("factory; ch1:volts 0.1, ");
            //autorange

            //trigger

            //data


            mbSession.RawIO.Write("data init; data:encdg ascii; data:stop 1024"); 
            //other
        }

        
    }


}
