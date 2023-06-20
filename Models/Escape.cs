class Escape{
    public static string[] IncognitasSalas{get; private set;} = new string [4] {"La oscuridad","El segundo","Fosforo","La tercera"};
    public static int estadoJuego{get; private set;} = 1;
 
    public static int GetEstadoJuego(){
       return estadoJuego; 
    }
    public static bool ResolverSala(int Sala, string Incognita){
        int i = Sala-1;
        bool v = IncognitasSalas[i] == Incognita;
        if(v){
           estadoJuego=Sala+1;
        }
        return v;
    }

}