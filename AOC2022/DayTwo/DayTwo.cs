// namespace AOC2022.DayTwo;
//
// public class DayTwo
// {
//
//     private void Solve()
//     {
//         var parsedInput = file
//             .Select(line => line.Split(" "))
//             .Select(characters => new KeyValuePair<string, string>(GetSensibleString(characters[0]), GetSensibleString(characters[1]))).ToList();
//         
//         const string ROCK = "Rock";
//         const string PAPER = "Paper";
//         const string SCISSORS = "Scissors";
//         
//         const string WIN = "Win";
//         const string LOSE = "Lose";
//         const string DRAW = "DRAW";
//         
//         var aggregateScore = parsedInput.Aggregate(0, (cumulativeScore, hand) =>
//         {
//             // Part One
//             // var handScore = hand.Value switch
//             // {
//             //     ROCK => 1,
//             //     PAPER => 2,
//             //     SCISSORS => 3,
//             //     _ => 0
//             // };
//             //
//             // var outcomeScore = hand.Key == hand.Value ? 3
//             //     : hand is { Key: ROCK, Value: PAPER } or { Key: PAPER, Value: SCISSORS } or { Key: SCISSORS, Value: ROCK } ? 6
//             //     : 0;
//             
//             // Part Two
//             var handPlayed = hand.Value switch
//             {
//                 WIN => GetWinningHand(hand.Key),
//                 LOSE => GetLosingHand(hand.Key),
//                 DRAW => hand.Key
//             };
//         
//             var handScore = handPlayed switch
//             {
//                 ROCK => 1,
//                 PAPER => 2,
//                 SCISSORS => 3,
//                 _ => 0
//             };
//             
//             var outcomeScore = hand.Value switch
//             {
//                 WIN => 6,
//                 DRAW => 3,
//                 _ => 0
//             };
//         
//             return cumulativeScore + handScore + outcomeScore;
//         });
//         
//         Console.WriteLine(aggregateScore);
//     }
//     
//
// string GetSensibleString(string value)
// {
//     return value switch
//     {
//         // Part one.
//         // "A" => ROCK,
//         // "B" => PAPER,
//         // "C" => SCISSORS,
//         // "X" => ROCK,
//         // "Y" => PAPER,
//         // "Z" => SCISSORS,
//         // _ => ""
//         
//         //Part 2 - X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win.
//         "A" => ROCK,
//         "B" => PAPER,
//         "C" => SCISSORS,
//         "X" => LOSE,
//         "Y" => DRAW,
//         "Z" => WIN,
//         _ => ""
//     };
// }
//
// string GetWinningHand(string key)
// {
//     return key switch
//     {
//         ROCK => PAPER,
//         PAPER => SCISSORS,
//         SCISSORS => ROCK
//     };
// }
//
// string GetLosingHand(string key)
// {
//     return key switch
//     {
//         ROCK => SCISSORS,
//         PAPER => ROCK,
//         SCISSORS => PAPER
//     };
// }
// }