using FileHelpers;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Data_Migration_Process_Creator
{
    [DelimitedRecord(",")]
    class LGA
    { 
        public int Id { get; set; }
        public string LocalGovtCode { get; set; }
        public string StateName { get; set; }
        public string LocalArea { get; set; }
    }

    [DelimitedRecord(",")] 
    class RegistrationArea
    {
        public int RegAreaId { get; set; }
        public string RegAreaCode { get; set; }
        public string RegAreaName { get; set; }
        public string LgaName { get; set; }
    }
    [DelimitedRecord(",")]
    class PollingUnit
    {
        public int ID { get; set; }
        public string Polling_Unit { get; set; }
        public string Code { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }
        public string Ward { get; set; }
        public string Voting_Points { get; set; }
        public string Registered_Voters { get; set; }
        public string PU_Agent { get; set; }
        public string PU_Agent_Supervisor { get; set; } = String.Empty;
        public string Data_Analyst { get; set; } = String.Empty;
    }

    
    [DelimitedRecord(",")]
    class AgentsProfile
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Others { get; set; }
        public string Email { get; set; } = "PROFETOKEKANEM@GMAIL.COM";
        public string Address { get; set; } = "Testing Estate";
        public string City { get; set; } 
        public string PostalCode { get; set; } = "300361";
        public string Country { get; set; } = "Nigeria";
        public string HomePhone { get; set; } = "234567890123";
        public string MobilePhone { get; set; } = "234567890123";
        public string WorkPhone { get; set; } = "234567890123";
        public string Extension { get; set; }
        public string Password { get; set; } = "V0T3Guard@#";
    }
    [DelimitedRecord(",")]
    class NewPU
    {
        public string state_id { get; set; }
        public string state { get; set; }
        public string lga_code { get; set; }
        public string lga_id { get; set; }
        public string lga_name { get; set; }
        public string ward_code { get; set; }
        public string ward_name { get; set; }
        public string poll_code { get; set; }
        public string poll_name { get; set; }
        public string delimitation { get; set; }
        public string remark { get; set; }
        public string unit_id { get; set; }
        public string ward_id { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
    }
    class Class1
    {
        public static Dictionary<string, string> _fields = new Dictionary<string, string>();
        public static string ComputeSHA512(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException();
            }

            byte[] bytes = Encoding.UTF8.GetBytes(s);
            bytes = SHA512.Create().ComputeHash(bytes);
            return Convert.ToBase64String(bytes).Substring(0, 86);
        }
        public static void ChangeLGA()
        {
            var source = @"C:\Users\Decagon001\Desktop\Voteguard-docs\River\RIVERSWardx.xlsx";
            string con = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;'", source);
            
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [RIVERSWard$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (!_fields.ContainsKey(dr[2].ToString()))
                        {
                            _fields.Add(dr[2].ToString(), dr[3].ToString());
                        }
                    }
                }
            }
        }

        public static void ChangeLGAInPU()
        {
            ChangeLGA();
            var source = @"C:\Users\Decagon001\Desktop\Voteguard-docs\River\RiverState.xlsx";
            string con = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;'", source);

            var pus = new List<NewPU>();
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var newPu = new NewPU
                        {
                            state_id = dr[0].ToString(),
                            state = dr[1].ToString(),
                            lga_code = dr[2].ToString(),
                            lga_id = dr[3].ToString(),
                            lga_name = _fields[dr[6].ToString()],
                            ward_code = dr[5].ToString(),
                            ward_name = dr[6].ToString().Replace(",",""),
                            poll_code = dr[7].ToString(),
                            poll_name = dr[8].ToString().Replace(",", ""),
                            delimitation = dr[9].ToString(),
                            remark = dr[10].ToString(),
                            unit_id = dr[11].ToString(),
                            ward_id = dr[12].ToString(),
                            lat = dr[13].ToString(),
                            lon = dr[14].ToString(),
                        };
                        
                        pus.Add(newPu);
                    }
                    WriteCSV(pus, "River", "NewPU");
                }
            }
        }
        public static void SaveToDb()
        {
            var lineNumber = 0;
            using (SqlConnection conn = new SqlConnection(@"Server=DECAGON;Database=VoteGuard_Dev_Db_01_04_2020;Trusted_Connection=True;"))
            {
                conn.Open();
                //Put your file location here:
                using (StreamReader reader = new StreamReader(@"C:\Users\Decagon001\Desktop\Voteguard-docs\NigerianPollingUnit.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (lineNumber != 0)
                        {
                            var v = line.Split(',');
                            //ID	Code	State	LGA	Ward	Polling_Unit	PU_Agent	PU_Agent_Supervisor	Data_Analyst				
                            //1	5	ABIA	1	EZIAMA	ABIA POLY - ABIA POLY I							


                            //var sql = "INSERT INTO TestPollingUnits VALUES ('" + values[0] + "','" + values[1] + "'," + values[2] + ")";
                            //var sql = "INSERT INTO TestPollingUnits VALUES ('" + v[1].Trim() + "','" + v[2].Trim() + "'," + v[3].Trim() + ",'" + v[4].Trim() + "','" + v[5].Trim() + "','" + v[6].Trim() + "','" + v[7].Trim() + "','" + v[8].Trim() +"')";

                            var cmd = new SqlCommand();
                            cmd.CommandText = "InsertPU";
                            cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.CommandType = System.Data.CommandType.Text;
                            
                            cmd.Parameters.AddWithValue("@Code", v[1]);
                            cmd.Parameters.AddWithValue("@State", v[2]);
                            cmd.Parameters.AddWithValue("@LGA", v[3]);
                            cmd.Parameters.AddWithValue("@Ward", v[4]);
                            cmd.Parameters.AddWithValue("@Polling_Unit", v[5]);
                            cmd.Parameters.AddWithValue("@PU_Agent", v[6]);
                            cmd.Parameters.AddWithValue("@PU_Agent_Supervisor", v[7]);
                            cmd.Parameters.AddWithValue("@Data_Analyst", v[8]);
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                        }
                        lineNumber++;
                    }
                }
                conn.Close();
            }
            Console.WriteLine("Products Import Complete");
            Console.ReadLine();
        }
        
        public static void CreatePollingUnitAgent()
        {
            
            var listState = new List<string>
            {
              "Akwa Ibom","Anambra","Bauchi","Bayelsa","Benue",
              "Borno","Cross River","Delta","Ebonyi","Edo","Ekiti",
              "Enugu","FCT","Gombe","Imo","Jigawa","Kaduna","Kano",
              "Katsina","Kebbi","Kogi","Kwara","Lagos","Nasarawa",
              "Niger","Ogun","Ondo","Osun","Oyo","Plateau","Rivers",
              "Sokoto","Taraba","Yobe","Zamfara"
            };
            var listPUAgennt = new List<AgentsProfile>();
            var v = 20128;
            var i = 0;
            var currentState = listState[i];
            var puCt = new List<int>{24479,30198,35610,37854,42923,47994,51262,57124,60064,64583,67027,71163,73980,76964,81721,86230,94214,105426,112076,115817,119324,122210,135532,138784,143730,148770,152700,156463,162852,167839,174703,178688,182285,185094,188623
            };
            var wdCt = new List<int>          {3714,5344,6404,6928,8308,9867,10831,12183,13040,14000,14882,16181,16493,17061,18594,20029,21304,23722,25528,26655,27847,28814,30039,30772,32143,33323,34337,35998,37754,38788,40385,41601,42444,43332,44068
            };
            var lgCt = new List<int>          {355,457,559,598,712,846,937,1063,1130,1217,1297,1382,1412,1470,1603,1739,1851,2073,2242,2346,2452,2533,2634,2700,2824,2924,3014,3162,3328,3415,3530,3644,3722,3808,3876};
            int a = 1;
            string states = listState[i];
            while(v <= 188623)
            {
                
                if (v > puCt[i])
                {
                    a++;
                    if (a > 3)
                    {
                        WritePUCSV(listPUAgennt, states, "PUAgent");
                        listPUAgennt = new List<AgentsProfile>();
                        states = ""; 
                        a = 1;
                    }
                    i++;
                    currentState = listState[i];
                    states += currentState;
                }
                //if (currentState == "Kaduna" || currentState == "Akwa Ibom")
                //{
                //    v = puCt[i]+1;
                //    i++;
                //}
                var puAgent = new AgentsProfile
                {
                    Username = "PU_Agent_"+v.ToString(),
                    FirstName = "PU Agent",
                    LastName = v.ToString(),
                    City = currentState,
                    DisplayName = "PU Agent "+ v.ToString()
                };
                listPUAgennt.Add(puAgent);
                v++;
            }
            WritePUCSV(listPUAgennt, states, "PUAgent");
            v = 2071;
            i = 0;
            currentState =  listState[i];
            listPUAgennt = new List<AgentsProfile>();
            a = 1;
            states = listState[i];
            while (v <= 44068)
            {
                
                if (v > wdCt[i])
                {
                    a++;
                    if (a > 3)
                    {
                        WritePUCSV(listPUAgennt, states, "PUSupervisor");
                        listPUAgennt = new List<AgentsProfile>();
                        states = "";
                        a = 1;
                    }
                    i++; 
                    currentState = listState[i];
                    states += currentState;
                }
                //if (currentState == "Kaduna" || currentState == "Akwa Ibom")
                //{
                //    v = wdCt[i] + 1;
                //    i++;
                //}
                var puAgent = new AgentsProfile
                {
                    Username = "PU_Supervisor_" + v.ToString(),
                    FirstName = "PU Supervisor",
                    LastName = v.ToString(),
                    City = currentState,
                    DisplayName = "PU Supervisor " + v.ToString()
                };
                listPUAgennt.Add(puAgent);
                v++;
            }
            WritePUCSV(listPUAgennt, states, "PUSupervisor");
            v = 201;
            i = 0;
            currentState = listState[i];
            listPUAgennt = new List<AgentsProfile>();
            a = 1;
            states = listState[i];
            while (v <= 3876)
            {
                
                if (v > lgCt[i])
                {
                    a++;
                    if (a > 3)
                    {
                        WritePUCSV(listPUAgennt, states, "LgaSupervisor");
                        listPUAgennt = new List<AgentsProfile>();
                        states = "";
                        a = 1;
                    }
                    i++; 
                    currentState = listState[i];
                    states += currentState;
                }
                //if (currentState == "Kaduna" || currentState == "Akwa Ibom")
                //{
                //    v = lgCt[i] + 1;
                //    i++;
                //}
                var puAgent = new AgentsProfile
                {
                    Username = "DataAnalyst_" + v.ToString(),
                    FirstName = "LGA Supervisor",
                    LastName = v.ToString(),
                    City = currentState,
                    DisplayName = "LGA Supervisor " + v.ToString()
                };
                listPUAgennt.Add(puAgent);
                v++;
            }
            WritePUCSV(listPUAgennt, states, "LgaSupervisor");
        }
        private static void WritePUCSV(List<AgentsProfile> listPUAgennt, string state, string level)
        {
            var engine = new FileHelperEngine<AgentsProfile>();
            engine.HeaderText = engine.GetFileHeader();

            //File location, where the .csv goes and gets stored.
            string filePath = Path.Combine("C:\\Users\\Decagon001\\Desktop\\Voteguard-docs\\Agents\\Combined", String.Format("{0}{1}" + ".csv",state,level));
            engine.WriteFile(filePath, listPUAgennt);
        }
        public static void Test()
        {
            
            var listPolling = new List<RegistrationArea>();
            //var source = "C:\\Users\\Decagon001\\Desktop\\Voteguard-docs\\NigerianPollingUnitList.xlsx";
            var source = @"C:\Users\Decagon001\Desktop\Voteguard-docs\NigerianPollingUnitList.xlsx";
            //var source = "C:\\Users\\Decagon001\\Desktop\\Voteguard-docs\\USER ACCOUNTS\\UserList_by_Roles_with_Credentails.xlsx";
            string con =String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;'", source);
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [state-lga-ward-poll-units$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    var currentWard = "";
                    while (dr.Read())
                    {
                        if (currentWard == dr[6].ToString()) continue;
                        currentWard = dr[6].ToString();
                        if (dr[1].ToString() != "ABIA") break;
                        var WardData = new RegistrationArea
                        {
                            RegAreaCode = dr[5].ToString()??"",
                            RegAreaName = dr[6].ToString()??"",
                            LgaName = dr[4].ToString() ?? "",
                        };
                        listPolling.Add(WardData);
                    }
                }
                var engine = new FileHelperEngine<RegistrationArea>();
                engine.HeaderText = engine.GetFileHeader();
                
                //File location, where the .csv goes and gets stored.
                string filePath = Path.Combine("C:\\Users\\Decagon001\\Desktop\\Voteguard-docs", "WardAbia.csv");
                engine.WriteFile(filePath, listPolling);
            }
        }
        public static void AddPUSup()
        {
            var listPolling = new List<PollingUnit>();
            var source = @"C:\Users\Decagon001\Desktop\Voteguard-docs\PUAbia.xlsx";
            string con = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;'", source);
            var wardCountPair = new Dictionary<string, int>();
            var lgaCountPair = new Dictionary<string, int>();
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [PUAbia$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    
                    while (dr.Read())
                    {
                        if(!wardCountPair.ContainsKey(dr[5].ToString()))
                        {
                            wardCountPair.Add(dr[5].ToString(), 1);
                        }else wardCountPair[dr[5].ToString()]++;
                        if (!lgaCountPair.ContainsKey(dr[4].ToString()))
                        {
                            lgaCountPair.Add(dr[4].ToString(), 1);
                        }
                        else lgaCountPair[dr[4].ToString()]++;
                    }
                }
                using(OleDbDataReader dr = command.ExecuteReader())
                {
                    int startSup = 21;
                    var currentWard = "EZIAMA";
                    int useSup = wardCountPair[currentWard] / 5;
                    int count = 1;
                    int wardCount = 0;
                    int startDat = 11;
                    var currentDat = "ABA NORTH";
                    int useDat = lgaCountPair[currentDat] / 5;
                    int lCount = 1;
                    int lgaCount = 0;
                    while (dr.Read())
                    {
                        
                        if (dr[5].ToString() != currentWard)
                        {
                            currentWard = dr[5].ToString();
                            useSup = wardCountPair[currentWard] / 5;
                            count = 1;
                            wardCount = 0;
                            startSup++;
                        }
                        if (dr[4].ToString() != currentDat)
                        {
                            currentDat = dr[4].ToString();
                            useDat = lgaCountPair[currentDat] / 5;
                            lCount = 1;
                            lgaCount = 0;
                            startDat++;
                        }
                        var puData = new PollingUnit
                        {
                            Polling_Unit = dr[1].ToString(),
                            Code = dr[2].ToString(),
                            State = dr[3].ToString(),
                            LGA = dr[4].ToString(),
                            Ward = dr[5].ToString(),
                            Voting_Points = dr[6].ToString(),
                            Registered_Voters = dr[7].ToString(),
                            PU_Agent = dr[8].ToString(),
                            PU_Agent_Supervisor = "PU_Supervisor_" + startSup,
                            Data_Analyst = "DataAnalyst_" + startDat,
                        }; 
                        count++;
                        wardCount++;
                        if (count > useSup)
                        {
                            count = 1;

                            if (wardCountPair[currentWard] - wardCount > 5) startSup++;
                        }
                        lCount++;
                        lgaCount++;
                        if (lCount > useDat)
                        {
                            lCount = 1;

                            if (lgaCountPair[currentDat] - lgaCount > 5) startDat++;
                        }
                        listPolling.Add(puData);
                    }
                    var engine = new FileHelperEngine<PollingUnit>();
                    engine.HeaderText = engine.GetFileHeader();

                    //File location, where the .csv goes and gets stored.
                    string filePath = Path.Combine("C:\\Users\\Decagon001\\Desktop\\Voteguard-docs", "AbiaPUAgentWard.csv");
                    engine.WriteFile(filePath, listPolling);
                }
            }
        }
        //S/N,POLLING UNIT,WARD,LGA,STATE
        //6864
        public static void SplitPUToState()
        {
            var agt = 1;
            var listPolling = new List<PollingUnit>();
            
            var source = @"C:\Users\Decagon001\Desktop\Voteguard-docs\River\Rivers-State.xlsx";
            string con = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;';Persist Security Info=True;", source);
            
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [rivers$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    var state = "";
                    var lga = "";
                    var ward = "";
                    var formatState = "";
                    var i = 0;
                    var puSup = 0;
                    var maxSup = 0;
                    var lgaSup = 0;
                    var maxLgaSup = 0;
                    int code = 1;
                    while (dr.Read())
                    {
                        if (dr[4].ToString() != state)
                        {
                            if (i != 0) WriteCSV(listPolling, state,"PU");
                            state = dr[4].ToString();
                            var splitState = state.Split(' ');
                            formatState = Char.ToUpper(splitState[0][0]) + splitState[0].Substring(1).ToLower() + 
                                ( splitState.Length > 1 ? " " + Char.ToUpper(splitState[1][0]) + splitState[1].Substring(1).ToLower():"") + " State";
                            i++;
                            formatState = formatState.StartsWith("Federal") ? "FCT" : formatState;
                            listPolling = new List<PollingUnit>();
                        }
                        if (dr[2].ToString() != ward)
                        {
                            ward = dr[2].ToString();
                            puSup = maxSup+1;
                            maxSup = puSup+4;
                            code = 1;
                        }
                        if(dr[3].ToString() != lga)
                        {
                            lga = dr[3].ToString();
                            lgaSup = maxLgaSup + 1;
                            maxLgaSup = lgaSup+4;
                            
                        }
                        var puData = new PollingUnit
                        {
                            Polling_Unit = dr[1].ToString().Replace(",",""),
                            Code = code.ToString(),
                            State = formatState,
                            LGA = dr[3].ToString(),
                            Ward = dr[2].ToString(),
                            PU_Agent = "PU_Agent_" + agt,
                            PU_Agent_Supervisor = "PU_Supervisor_" + puSup,
                            Data_Analyst = "DataAnalyst_" + lgaSup,
                        };
                        listPolling.Add(puData);
                        agt++;
                        puSup++;
                        lgaSup++;
                        code++;
                        if(puSup > maxSup) puSup -= 5;
                        if(lgaSup > maxLgaSup) lgaSup -= 5;

                    }
                    WriteCSV(listPolling, state,"PU");
                }
            }

        }
        public static void SplitLGAWardToState()
        {
            
            var listWards = new List<RegistrationArea>();
            var listLGA = new List<LGA>();

            var source = @"C:\Users\Decagon001\Desktop\Voteguard-docs\inec_pu_new.xlsx";
            string con = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;';Persist Security Info=True;", source);

            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [inec_pu$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    var state = "";
                    var lga = "";
                    var ward = "";
                    var formatState = "";
                    var i = 0;
                    var wC = 1;
                    var lC = 1;
                    while (dr.Read())
                    {
                        if (dr[4].ToString() != state)
                        {
                            if (i != 0)
                            {
                                WriteCSV(listWards, state,"Ward");
                                WriteCSV(listLGA, state,"LGA");
                            }
                            state = dr[4].ToString();
                            var splitState = state.Split(' ');
                            formatState = Char.ToUpper(splitState[0][0]) + splitState[0].Substring(1).ToLower() +
                                (splitState.Length > 1 ? " " + Char.ToUpper(splitState[1][0]) + splitState[1].Substring(1).ToLower() : "") + " State";
                            i++;
                            formatState = formatState.StartsWith("Federal") ? "FCT" : formatState;
                            listWards = new List<RegistrationArea>();
                            listLGA = new List<LGA>();
                            lC = 1; wC = 1;
                        }
                        if (dr[3].ToString() != lga)
                        {
                            var newLga = new LGA
                            {
                                LocalGovtCode = lC.ToString(),
                                StateName = formatState,
                                LocalArea = dr[3].ToString()
                            };
                            listLGA.Add(newLga);
                            lga = dr[3].ToString();
                            lC++;
                        }
                        if (dr[2].ToString() != ward)
                        {
                            var newWard = new RegistrationArea
                            {
                                RegAreaCode = wC.ToString(),
                                RegAreaName = dr[2].ToString(),
                                LgaName = lga,
                            };
                            listWards.Add(newWard);
                            ward = dr[2].ToString();
                            wC++;
                        }

                    }
                    WriteCSV(listWards, state,"Ward");
                    WriteCSV(listLGA, state,"LGA");
                }
            }

        }
        private static void WriteCSV<T>(List<T> listPolling, string state, string loc) where T : class
        {
            var engine = new FileHelperEngine<T>();
            engine.HeaderText = engine.GetFileHeader();

            //File location, where the .csv goes and gets stored.
            string filePath = Path.Combine(String.Format("C:\\Users\\Decagon001\\Desktop\\Voteguard-docs\\River",loc), String.Format("{0}{1}.csv", state,loc));
            engine.WriteFile(filePath, listPolling);
        }
        public static void Main()
        {
            ChangeLGAInPU();
            
        }
    }
}