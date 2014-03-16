using System;

namespace RecursiveFunctions
{
    public class RecursiveOperations
    {
        #region Contractions

        static readonly Z Z = new Z();

        static readonly N N = new N();

        static U U(int i)
        {
            return new U(i);
        }

        static S S(params RecursiveFunction[] fs)
        {
            return new S(fs);
        }

        static R R(params RecursiveFunction[] fs)
        {
            return new R(fs);
        }

        static M M(RecursiveFunction f)
        {
            return new M(f);
        }

        #endregion

        static void Main()
        {
            Console.WriteLine("Nothing is done here, see unit tests pls.");
        }

        #region Addition
        public static RecursiveFunction Add = R(U(1), S(N, U(3)));
        #endregion

        #region Multiplication
        public static RecursiveFunction Mul = R(Z, S(Add, U(1), U(3)));
        public static RecursiveFunction Pow = R(S(N, Z), S(Mul, U(1), U(3)));
        #endregion

        #region Substraction
        public static RecursiveFunction Dec = R(Z, U(1));               
        public static RecursiveFunction Sub = R(U(1), S(Dec, U(3)));    
        #endregion

        #region Comparison
        public static RecursiveFunction Eq0 = R(S(N, Z), Z); // equals to 0
        public static RecursiveFunction Leq = S(Eq0, Sub);   // less or equal
        public static RecursiveFunction Les = S(Mul, S(Leq, U(1), U(2)), S(Leq, S(N, U(1)), U(2))); // strictly less
        public static RecursiveFunction Eqs = S(Mul, S(Leq, U(1), U(2)), S(Leq, U(2), U(1))); // strictly equal
        #endregion

        #region Conditional
        public static RecursiveFunction If = S(R(U(2), U(1)), U(2), U(3), U(1)); // a ? b : c
        public static RecursiveFunction Not = S(R(N, Z), U(1), U(1));           
        #endregion

        #region Division
        public static RecursiveFunction Dmx = S(R(Z     // max {x} : (x < a && x is divisable by b)
                                                , S(If
                                                  , S(Eqs
                                                      , S(Sub, S(N, U(2)), U(3))
                                                      , U(1))
                                                  , S(N, U(2))
                                                  , U(3)))
                                              , U(2)
                                              , U(1));

        public static RecursiveFunction Div = S(R(Z 
                                                , S(Add
                                                  , U(3)
                                                  , S(Eqs
                                                    , S(Dmx
                                                      , S(N, U(2))
                                                      , U(1))
                                                    , S(N, U(2)))))
                                              , U(2)
                                              , U(1));

        public static RecursiveFunction Mod = S(Sub
                                              , U(1)
                                              , S(Mul
                                                , S(Div, U(1), U(2))
                                                , U(2))
                                              );
        #endregion

        #region Primes
        public static RecursiveFunction IsP = S(Not             // is prime?
                                              , S(Sub
                                                , S(R(Z
                                                  , S(Add
                                                    , U(3)
                                                    , S(Eq0
                                                      , S(Mod
                                                        , U(1)
                                                        , U(2)))))
                                                  , U(1)
                                                  , U(1))
                                                , S(N, Z)));

        public static RecursiveFunction NeP = S(Add             // next prime
                                              , M(S(Not
                                                  , S(IsP
                                                    , S(Add
                                                      , S(N, U(1))
                                                      , U(2)))))
                                              , S(N, U(1)));

        public static RecursiveFunction ThP = R(S(N, S(N, Z))   // n-th prime
                                              , S(NeP, U(2)));

        #endregion

        #region Logarithm
        public static RecursiveFunction Log = S(Dec
                                              , M(S(Eq0
                                                , S(Mod
                                                  , U(2)
                                                  , S(Pow
                                                    , U(1)
                                                    , U(3))))));
        #endregion
    }

    public delegate int Call(params int[] args);
}
