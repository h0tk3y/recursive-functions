using System;

namespace RecursiveFunctions
{
    public abstract class RecursiveFunction
    {
        protected RecursiveFunction(params RecursiveFunction[] functionArgs)
        {
            FunctionArgs = functionArgs;
        }

        public RecursiveFunction[] FunctionArgs { get; private set; }
        public abstract int Call(params int[] args);

        public static implicit operator Call(RecursiveFunction r)
        {
            return r.Call;
        }
    }

    class Z : RecursiveFunction
    {
        public override int Call(params int[] args)
        {
            return 0;
        }
    }

    class N : RecursiveFunction
    {
        public override int Call(params int[] args)
        {
            return args[0] + 1;
        }
    }

    class U : RecursiveFunction
    {
        public U(int target)
        {
            Target = target;
        }

        public int Target { get; private set; }

        public override int Call(params int[] args)
        {
            return args[Target - 1];
        }
    }

    class S : RecursiveFunction
    {
        public override int Call(params int[] args)
        {
            int[] results = new int[FunctionArgs.Length - 1];
            for (int i = 0; i < FunctionArgs.Length - 1; i++)
                results[i] = FunctionArgs[i + 1].Call(args);
            return FunctionArgs[0].Call(results);
        }

        public S(params RecursiveFunction[] fs)
            : base(fs)
        {
        }
    }

    class R : RecursiveFunction
    {
        public override int Call(params int[] args)
        {
            if (args[args.Length - 1] == 0)
                return FunctionArgs[0].Call(args.SubArray(0, args.Length - 1));

            int[] gArgs = new int[args.Length + 1];
            Array.Copy(args, gArgs, args.Length);
            gArgs[gArgs.Length - 2]--;

            args[args.Length - 1]--;
            gArgs[gArgs.Length - 1] = Call(args);
            args[args.Length - 1]++;

            return FunctionArgs[1].Call(gArgs);
        }

        public R(params RecursiveFunction[] fs)
            : base(fs)
        {
        }
    }

    class M : RecursiveFunction
    {
        public override int Call(params int[] args)
        {
            int[] fArgs = new int[args.Length + 1];
            Array.Copy(args, fArgs, args.Length);
            for (fArgs[fArgs.Length - 1] = 0; fArgs[fArgs.Length - 1] < int.MaxValue; ++fArgs[fArgs.Length - 1])
                if (FunctionArgs[0].Call(fArgs) == 0)
                    return fArgs[fArgs.Length-1];
            return -1;
        }

        public M(RecursiveFunction f)
            : base(new[] { f })
        {
        }
    }

    static class Extensions
    {
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}