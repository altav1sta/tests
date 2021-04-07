import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';

function Square(props) {
    const classes = props.winner ? 'square square-winner' : 'square';
    return (
        <button className={classes} onClick={props.onClick}>
            {props.value}
        </button>
    );
}

class Board extends React.Component {
    renderSquare(i, winner) {
        return (
            <Square
                key={i}
                value={this.props.squares[i]}
                winner={winner}
                onClick={() => this.props.onClick(i)} />
        );
    }

    render() {
        const count = Math.sqrt(this.props.squares.length);
        const rows = [...Array(count).keys()].map(i => {
            const squares = [...Array(count).keys()].map(j => {
                const index = i * count + j;
                const winner = this.props.winnerLine ? this.props.winnerLine.includes(index) : false;
                return this.renderSquare(index, winner);
            });

            return (
                <div key={i} className="board-row">
                    {squares}
                </div>
            );
        });
        return <div>{rows}</div>;
    }
}

class Game extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            history: [{
                squares: Array(9).fill(null),
                x: null,
                y: null,
            }],
            stepNumber: 0,
            xIsNext: true,
            ascending: true,
        };
        this.toggleSortOrder = this.toggleSortOrder.bind(this);
    }

    handleClick(i) {
        const history = this.state.history.slice(0, this.state.stepNumber + 1);
        const current = history[history.length - 1];
        const squares = current.squares.slice();
        const x = Math.floor(i / 3) + 1;
        const y = i % 3 + 1;

        if (calculateWinnerLine(squares) || squares[i]) return;

        squares[i] = this.state.xIsNext ? 'X' : 'O';
        this.setState({
            history: history.concat([{
                squares: squares,
                x: x,
                y: y,
            }]),
            stepNumber: history.length,
            xIsNext: !this.state.xIsNext,
        });
    }

    jumpTo(step) {
        this.setState({
            stepNumber: step,
            xIsNext: (step % 2) === 0,
        });
    }

    toggleSortOrder() {
        this.setState({ ascending: !this.state.ascending });
    }

    render() {
        const history = this.state.history.slice();
        const current = history[this.state.stepNumber];
        const winnerLine = calculateWinnerLine(current.squares);
        const winner = winnerLine ? current.squares[winnerLine[0]] : null;
        const status = winner
            ? ('Winner: ' + winner)
            : (history.length === current.squares.length + 1
                ? 'Draw'
                : ('Next player: ' + (this.state.xIsNext ? 'X' : 'O')));

        if (!this.state.ascending) history.reverse();

        const moves = history.map((step, index) => {
            const move = this.state.ascending ? index : history.length - index - 1;
            const desc = move ? 'Go to move #' + move + ' (' + step.x + ',' + step.y + ')' : 'Go to start';
            return (
                <li key={move}>
                    <button onClick={() => this.jumpTo(move)}>
                        {
                            move === this.state.stepNumber
                                ? <b>{desc}</b>
                                : desc
                        }
                    </button>
                </li>
            );
        });

        return (
            <div className="game">
                <div className="game-board">
                    <Board
                        squares={current.squares}
                        winnerLine={winnerLine}
                        onClick={(i) => this.handleClick(i)} />
                </div>
                <div className="game-info">
                    <div>{status}</div>
                    <div>
                        <h3>Move history</h3>
                        <button onClick={this.toggleSortOrder}>
                            {this.state.ascending ? 'Sort by descending' : 'Sort by ascending'}
                        </button>
                        <ol>{moves}</ol>
                    </div>
                </div>
            </div>
        );
    }
}

// ========================================

ReactDOM.render(
    <Game />,
    document.getElementById('root')
);

function calculateWinnerLine(squares) {
    const lines = [
        [0, 1, 2],
        [3, 4, 5],
        [6, 7, 8],
        [0, 3, 6],
        [1, 4, 7],
        [2, 5, 8],
        [0, 4, 8],
        [2, 4, 6],
    ];
    for (let i = 0; i < lines.length; i++) {
        const [a, b, c] = lines[i];
        if (squares[a] && squares[a] === squares[b] && squares[a] === squares[c]) {
            return lines[i];
        }
    }
    return null;
}