using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WinFormsApp1
{
    internal abstract class Piece
    {
        public Image Image { get; set; }
        public String Color { get; set; }

        public abstract List<Tuple<int, int>> getPosibileMoves2(Tuple<int, int> coord, Model boardModel);

        public bool isPromoted()
        {
            if (this is Pawn || this is Bishop || this is Rook || this is Lance || this is Knight || this is Silver)
            {
                return false;
            }
            return true;
        }

        public Piece demotePiece()
        {
            if (isPromoted())
            {
                switch (this)
                {
                    case PawnP: { return new Pawn(this.Color); }
                    case BishopP: { return new Bishop(Color); }
                    case RookP: { return new Rook(Color); }
                    case LanceP: { return new Lance(this.Color); }
                    case KnightP: { return new Knight(this.Color); }
                    case SilverP: { return new Silver(this.Color); }
                }
            }
            return this;
        }

        public Piece promotePiece()
        {
            switch (this)
            {
                case Pawn: { return (new PawnP(this.Color)); }
                case Bishop: { return (new BishopP(this.Color)); }
                case Rook: { return (new RookP(this.Color)); }
                case Lance: { return (new LanceP(this.Color)); }
                case Knight: { return (new KnightP(this.Color)); }
                case Silver: { return (new SilverP(this.Color)); }
                default: { return new Pawn(this.Color); };
            }
        }
    }
}
