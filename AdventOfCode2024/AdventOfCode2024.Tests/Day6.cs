﻿using AdventOfCode2024.Day6;
using FluentAssertions;

namespace AdventOfCode2024.Tests;

public class Day6
{
    private string[] input = new[]
    {
        "....#.....",
        ".........#",
        "..........",
        "..#.......",
        ".......#..",
        "..........",
        ".#..^.....",
        "........#.",
        "#.........",
        "......#...",
    };

    [Test]
    public void Test1()
    {
        // Arrange
        var world = InputReader.Read(this.input);

        // Act
        world.Simulate();
        var total = world.GetTotalVisited();

        // Assert
        total.Should().Be(41);
    }

    [Test]
    public void Test2()
    {
        // Arrange
        var world = InputReader.Read(this.input);

        // Act
        world.Simulate(true);
        var total = world.GetLoops();

        // Assert
        total.Should().HaveCount(6);

        // Reversed
        // total.Select(x => x.Postion).Should().BeEquivalentTo(new[]
        // {
        //     "3,3",
        //     "6,2",
        //     "7,2",
        //     "1,1",
        //     "3,1",
        //     "7,0",
        // });

        // normal
        total.Select(x => x.Postion).Should().BeEquivalentTo(new[]
        {
            "3,6",
            "6,7",
            "7,7",
            "1,8",
            "3,8",
            "7,9",
        });
    }


    [Test]
    public void TestJ()
    {
        var looped = new[]
        {
            "39,3","43,3","47,3","48,3","51,3","54,3","58,3","59,3","61,3","66,3","67,3","70,3","72,3","75,3","81,3","82,3","45,5","47,5","48,5","51,5","54,5","70,5","82,5","44,7","79,7","82,7","85,7","87,7","89,7","39,8","44,8","77,8","22,9","23,9","24,9","26,9","27,9","36,9","39,9","41,9","77,10","20,11","21,11","22,11","23,11","24,11","26,11","27,11","36,11","37,11","39,11","41,11","43,11","45,11","47,11","48,11","49,11","51,11","54,11","77,11","14,12","17,12","18,12","22,12","23,12","24,12","26,12","27,12","36,12","37,12","39,12","41,12","42,12","43,12","44,12","45,12","47,12","48,12","49,12","51,12","54,12","57,12","59,12","60,12","14,13","17,13","18,13","22,13","23,13","24,13","26,13","27,13","39,13","41,13","45,13","47,13","48,13","49,13","51,13","54,13","60,13","65,13","70,13","75,13","77,13","78,13","79,13","82,13","94,13","9,14","14,14","18,14","20,14","39,14","44,14","77,14","39,15","41,15","45,15","48,15","54,15","62,15","65,15","70,15","75,15","84,15","85,15","87,15","89,15","94,15","102,15","104,15","109,15","116,15","9,16","14,16","18,16","20,16","9,17","14,17","18,17","20,17","33,17","39,17","44,17","60,17","77,17","117,17","9,18","14,18","18,18","20,18","33,18","39,18","42,18","44,18","54,18","62,18","87,18","94,18","99,18","102,18","104,18","23,19","28,19","30,19","31,19","32,19","39,19","40,19","42,19","43,19","47,19","48,19","54,19","55,19","60,19","61,19","62,19","64,19","67,19","14,20","20,20","33,20","39,20","42,20","44,20","54,20","60,20","77,20","80,20","82,20","94,20","20,21","33,21","35,21","36,21","39,21","44,21","45,21","46,21","48,21","54,21","59,21","62,21","65,21","69,21","70,21","72,21","75,21","76,21","77,21","79,21","84,21","87,21","99,21","102,21","104,21","107,21","14,22","20,22","39,22","42,22","44,22","54,22","60,22","77,22","80,22","82,22","94,22","108,22","110,22","111,22","116,22","118,22","124,22","125,22","14,23","16,23","23,23","26,23","27,23","30,23","33,23","35,23","36,23","39,23","44,23","45,23","47,23","48,23","49,23","108,23","115,23","117,23","128,23","9,24","14,24","20,24","33,24","39,24","44,24","77,24","85,24","87,24","89,24","95,24","108,24","115,24","117,24","20,25","39,25","42,25","50,25","77,25","85,25","117,25","128,25","14,26","16,26","20,26","25,26","26,26","27,26","30,26","31,26","33,26","34,26","35,26","36,26","37,26","39,26","43,26","44,26","45,26","46,26","47,26","48,26","49,26","51,26","52,26","53,26","54,26","57,26","58,26","59,26","61,26","62,26","63,26","65,26","94,26","95,26","128,26","14,27","20,27","25,27","39,27","44,27","77,27","80,27","82,27","9,28","11,28","14,28","15,28","16,28","17,28","20,28","21,28","23,28","28,28","29,28","30,28","31,28","32,28","33,28","34,28","35,28","39,28","40,28","42,28","44,28","50,28","54,28","56,28","60,28","66,28","12,29","39,29","44,29","54,29","60,29","66,29","77,29","80,29","82,29","85,29","94,29","95,29","108,29","11,30","44,30","50,30","54,30","60,30","62,30","65,30","69,30","70,30","71,30","75,30","76,30","77,30","84,30","85,30","87,30","89,30","90,30","92,30","94,30","95,30","99,30","101,30","102,30","109,30","12,31","16,31","20,31","25,31","44,31","47,31","50,31","51,31","54,31","55,31","57,31","60,31","61,31","62,31","64,31","66,31","67,31","69,31","70,31","71,31","72,31","74,31","75,31","76,31","78,31","80,31","82,31","94,31","95,31","102,31","117,31","9,32","11,32","20,32","25,32","39,32","54,32","60,32","66,32","82,32","85,32","109,32","7,33","11,33","16,33","25,33","39,33","40,33","41,33","42,33","43,33","44,33","47,33","48,33","50,33","51,33","54,33","55,33","57,33","60,33","61,33","62,33","64,33","66,33","82,33","95,33","7,34","9,34","11,34","16,34","20,34","25,34","54,34","82,34","102,34","16,35","20,35","25,35","34,35","36,35","60,35","62,35","77,35","82,35","85,35","94,35","95,35","102,35","108,35","115,35","117,35","128,35","20,36","25,36","30,36","33,36","37,36","53,36","54,36","60,36","62,36","70,36","82,36","21,37","26,37","28,37","30,37","31,37","32,37","33,37","34,37","35,37","37,37","39,37","40,37","41,37","42,37","43,37","44,37","47,37","48,37","50,37","51,37","55,37","57,37","60,37","74,37","82,37","95,37","21,38","30,38","37,38","54,38","82,38","85,38","94,38","95,38","102,38","117,38","128,38","7,39","9,39","11,39","16,39","20,39","30,39","33,39","37,39","50,39","54,39","62,39","66,39","69,39","71,39","75,39","76,39","77,39","82,39","85,39","87,39","89,39","92,39","94,39","95,39","102,39","108,39","11,40","36,40","45,40","48,40","52,40","53,40","59,40","62,40","65,40","69,40","71,40","75,40","76,40","77,40","85,40","87,40","109,40","12,41","30,41","37,41","54,41","66,41","77,41","82,41","85,41","109,41","50,42","54,42","62,42","66,42","71,42","75,42","76,42","77,42","82,42","85,42","87,42","89,42","92,42","95,42","100,42","101,42","102,42","104,42","106,42","109,42","116,42","118,42","123,42","7,43","9,43","11,43","16,43","20,43","30,43","33,43","37,43","50,43","54,43","74,43","82,43","85,43","88,43","92,43","94,43","95,43","102,43","108,43","115,43","117,43","123,43","11,44","47,44","48,44","52,44","53,44","54,44","62,44","66,44","71,44","77,44","82,44","85,44","109,44","123,44","128,44","30,45","66,45","77,45","85,45","109,45","9,46","11,46","12,46","30,46","37,46","50,46","54,46","82,46","85,46","95,46","109,46","9,47","11,47","16,47","20,47","24,47","28,47","32,47","33,47","34,47","36,47","39,47","41,47","44,47","46,47","47,47","48,47","49,47","50,47","51,47","52,47","53,47","54,47","55,47","56,47","57,47","58,47","59,47","60,47","61,47","62,47","63,47","64,47","66,47","67,47","69,47","71,47","72,47","73,47","75,47","76,47","77,47","78,47","79,47","81,47","82,47","83,47","85,47","88,47","92,47","94,47","95,47","102,47","109,47","9,48","11,48","14,48","15,48","17,48","20,48","62,48","66,48","71,48","77,48","78,48","80,48","83,48","85,48","90,48","92,48","95,48","96,48","98,48","99,48","101,48","102,48","108,48","109,48","117,48","11,49","12,49","16,49","20,49","24,49","28,49","30,49","33,49","37,49","39,49","54,49","62,49","66,49","71,49","82,49","83,49","85,49","92,49","94,49","95,49","109,49","11,50","36,50","47,50","48,50","52,50","53,50","62,50","69,50","71,50","75,50","76,50","81,50","83,50","85,50","87,50","92,50","94,50","95,50","101,50","106,50","109,50","115,50","117,50","123,50","128,50","11,51","14,51","15,51","19,51","21,51","23,51","25,51","27,5 1","29,51","31,51","32,51","34,51","37,51","39,51","42,51","50,51","54,51","57,51","62,51","66,51","71,51","82,51","83,51","85,51","88,51","92,51","94,51","95,51","106,51","109,51","123,51","128,51","12,52","16,52","20,52","28,52","30,52","50,52","54,52","57,52","66,52","82,52","83,52","85,52","92,5 2","94,52","95,52","20,53","50,53","58,53","61,53","75,53","85,53","123,53","124,53","128,53","20,54","28,54","30,54","54,54","82,54","83,54","85,54","95,54","109,54","124,54","12,55","27,55","32,55","34,55","36,55","41,55","44,55","48,55","49,55","50,55","51,55","57,55","58,55","61,55","63,55","64, 55","71,55","74,55","75,55","78,55","79,55","81,55","83,55","85,55","87,55","88,55","89,55","92,55","93,55","94,55","95,55","97,55","98,55","99,55","101,55","102,55","103,55","104,55","107,55","109,55","110,55","111,55","118,55","30,56","53,56","54,56","82,56","83,56","20,57","28,57","30,57","37,57" ,"38,57","41,57","44,57","50,57","54,57","57,57","63,57","64,57","66,57","69,57","70,57","75,57","77,57","80,57","82,57","83,57","85,57","92,57","96,57","99,57","104,57","105,57","106,57","108,57","109,57","110,57","111,57","115,57","117,57","118,57","119,57","123,57","124,57","20,58","21,58","28,58 ","30,58","37,58","47,58","49,58","50,58","51,58","53,58","57,58","58,58","78,58","82,58","83,58","92,58","94,58","95,58","111,58","124,58","128,58","30,59","47,59","53,59","54,59","82,59","83,59","92,59","12,60","20,60","21,60","24,60","28,60","30,60","33,60","35,60","37,60","39,60","46,60","47,60" ,"50,60","53,60","54,60","66,60","71,60","78,60","82,60","83,60","88,60","92,60","94,60","95,60","106,60","108,60","111,60","117,60","124,60","5,61","20,61","28,61","30,61","37,61","46,61","50,61","54,61","66,61","71,61","85,61","109,61","5,62","7,62","16,62","20,62","21,62","28,62","30,62","37,62", "47,62","54,62","83,62","85,62","89,62","92,62","95,62","111,62","117,62","124,62","128,62","33,63","37,63","39,63","47,63","53,63","66,63","71,63","75,63","82,63","83,63","85,63","92,63","95,63","111,63","115,63","117,63","124,63","128,63","9,64","12,64","28,64","30,64","37,64","46,64","47,64","57, 64","59,64","71,64","75,64","83,64","85,64","89,64","105,64","106,64","108,64","111,64","117,64","118,64","124,64","128,64","25,65","28,65","30,65","31,65","34,65","35,65","37,65","39,65","40,65","41,65","42,65","45,65","46,65","47,65","50,65","54,65","55,65","57,65","63,65","64,65","66,65","69,65", "74,65","75,65","80,65","82,65","83,65","88,65","95,65","96,65","104,65","30,66","31,66","32,66","34,66","35,66","36,66","37,66","38,66","39,66","40,66","41,66","42,66","43,66","44,66","45,66","46,66","47,66","48,66","50,66","51,66","52,66","54,66","55,66","56,66","57,66","59,66","60,66","61,66","62 ,66","63,66","64,66","65,66","66,66","68,66","69,66","70,66","71,66","72,66","74,66","75,66","76,66","77,66","78,66","79,66","80,66","82,66","83,66","88,66","92,66","94,66","95,66","99,66","101,66","111,66","117,66","124,66","128,66","66,67","71,67","75,67","85,67","108,67","111,67","115,67","117,67 ","124,67","128,67","20,68","28,68","37,68","46,68","47,68","50,68","54,68","59,68","92,68","94,68","95,68","111,68","124,68","128,68","20,69","23,69","24,69","25,69","30,69","32,69","34,69","36,69","38,69","40,69","41,69","43,69","44,69","45,69","46,69","47,69","50,69","53,69","54,69","57,69","59,6 9","62,69","66,69","71,69","75,69","78,69","81,69","82,69","85,69","88,69","92,69","95,69","105,69","108,69","109,69","111,69","117,69","28,70","35,70","37,70","39,70","47,70","53,70","54,70","62,70","66,70","71,70","75,70","85,70","95,70","5,71","24,71","25,71","37,71","38,71","39,71","40,71","41,7 1","42,71","43,71","45,71","46,71","47,71","48,71","50,71","51,71","52,71","54,71","55,71","56,71","57,71","59,71","60,71","61,71","62,71","63,71","64,71","65,71","66,71","68,71","69,71","70,71","71,71","72,71","74,71","75,71","76,71","77,71","78,71","79,71","80,71","82,71","109,71","6,72","10,72"," 11,72","15,72","16,72","17,72","18,72","19,72","20,72","23,72","24,72","25,72","26,72","28,72","47,72","54,72","85,72","92,72","95,72","3,73","11,73","13,73","26,73","28,73","33,73","39,73","51,73","52,73","56,73","58,73","63,73","67,73","69,73","79,73","88,73","92,73","94,73","95,73","99,73","101,7 3","4,74","7,74","36,74","55,74","64,74","80,74","83,74","88,74","95,74","96,74","97,74","104,74","108,74","111,74","117,74","26,75","28,75","47,75","50,75","54,75","57,75","59,75","74,75","78,75","79,75","88,75","92,75","94,75","95,75","99,75","101,75","108,75","111,75","117,75","124,75","128,75"," 4,76","7,76","12,76","21,76","24,76","26,76","28,76","31,76","32,76","34,76","36,76","38,76","40,76","41,76","44,76","47,76","50,76","51,76","52,76","56,76","57,76","58,76","63,76","67,76","69,76","72,76","78,76","79,76","80,76","83,76","84,76","87,76","88,76","89,76","91,76","92,76","93,76","94,76" ,"95,76","96,76","99,76","101,76","24,77","41,77","42,77","45,77","54,77","55,77","57,77","59,77","64,77","66,77","69,77","79,77","95,77","96,77","99,77","101,77","108,77","111,77","115,77","117,77","124,77","128,77","4,78","7,78","12,78","24,78","26,78","28,78","31,78","33,78","40,78","47,78","49,7 8","50,78","53,78","54,78","57,78","59,78","78,78","79,78","88,78","92,78","94,78","95,78","96,78","99,78","101,78","108,78","111,78","117,78","124,78","128,78","4,79","7,79","16,79","21,79","26,79","28,79","31,79","34,79","38,79","41,79","42,79","45,79","47,79","50,79","54,79","55,79","78,79","79,7 9","92,79","95,79","96,79","109,79","26,80","28,80","50,80","54,80","66,80","70,80","74,80","76,80","77,80","8,81","9,81","11,81","15,81","19,81","20,81","22,81","24,81","26,81","30,81","32,81","34,81","35,81","37,81","38,81","41,81","42,81","43,81","45,81","46,81","48,81","51,81","52,81","54,81","7 9,81","4,82","12,82","21,82","24,82","26,82","28,82","31,82","47,82","54,82","79,82","91,82","95,82","97,82","102,82","109,82","110,82","112,82","118,82","122,82","26,83","28,83","31,83","47,83","71,83","95,83","96,83","26,84","28,84","40,84","50,84","54,84","79,84","128,84","12,85","24,85","26,85", "31,85","32,85","33,85","35,85","37,85","38,85","41,85","43,85","45,85","47,85","50,85","54,85","74,85","80,85","82,85","95,85","97,85","110,85","16,86","17,86","24,86","32,86","49,86","54,86","79,86","92,86","94,86","95,86","96,86","109,86","111,86","118,86","128,86","20,87","21,87","22,87","54,87" ,"79,87","85,87","89,87","91,87","93,87","95,87","96,87","100,87","102,87","128,87","12,88","32,88","41,88","45,88","54,88","63,88","66,88","80,88","82,88","88,88","128,88","8,89","9,89","11,89","26,89","28,89","31,89","32,89","40,89","47,89","49,89","54,89","75,89","80,89","82,89","88,89","95,89"," 101,89","103,89","110,89","111,89","128,89","16,90","17,90","26,90","32,90","47,90","49,90","54,90","79,90","84,90","92,90","94,90","95,90","96,90","99,90","103,90","128,90","16,91","17,91","26,91","28,91","31,91","47,91","49,91","53,91","84,91","96,91","103,91","121,91","122,91","124,91","31,92","4 1,92","53,92","57,92","66,92","71,92","75,92","81,92","83,92","89,92","91,92","95,92","96,92","100,92","47,93","49,93","53,93","84,93","91,93","115,93","26,94","28,94","32,94","54,94","96,94","103,94","27,95","28,95","30,95","31,95","47,95","49,95","53,95","54,95","63,95","80,95","96,95","99,95","10 3,95","109,95","66,96","71,96","79,96","92,96","96,96","103,96","30,97","31,97","32,97","34,97","36,97","37,97","38,97","39,97","41,97","42,97","44,97","45,97","46,97","48,97","50,97","51,97","52,97","54,97","61,97","63,97","74,97","75,97","80,97","81,97","88,97","95,97","16,98","31,98","47,98","49, 98","53,98","73,98","79,98","92,98","94,98","96,98","103,98","109,98","16,99","20,99","21,99","26,99","32,99","37,99","38,99","40,99","41,99","47,99","50,99","51,99","52,99","54,99","55,99","60,99","61,99","63,99","64,99","65,99","69,99","70,99","72,99","73,99","74,99","75,99","76,99","80,99","82,99 ","87,99","88,99","90,99","91,99","92,99","96,99","103,99","109,99","79,100","96,100","103,100","115,100","47,101","49,101","53,101","79,101","81,101","39,102","47,102","48,102","50,102","51,102","52,102","55,102","58,102","60,102","62,102","63,102","64,102","65,102","67,102","69,102","70,102","71,1 02","72,102","73,102","74,102","75,102","76,102","77,102","78,102","79,102","80,102","81,102","82,102","83,102","84,102","85,102","87,102","88,102","90,102","91,102","95,102","79,104","94,104","79,105","94,105","103,105","109,105","53,106","55,106","63,106","64,106","65,106","70,106","72,106","74,10 6","75,106","76,106","80,106","82,106","88,106","90,106","97,106","98,106","99,106","100,106","104,106","105,106","107,106","49,107","52,107","57,107","74,107","75,107","83,107","85,107","87,107","89,107","103,107","79,108","91,108","52,109","53,109","55,109","63,109","64,109","65,109","70,109","72, 109","74,109","75,109","76,109","80,109","82,109","83,109","88,109","90,109","94,109","97,109","98,109","99,109","100,109","101,109","102,109","103,109","22,110","31,110","39,110","49,110","79,110","81,110","91,110","41,111","43,111","63,111","91,111","94,111","79,112","91,112","94,112","20,113","25 ,113","26,113","49,113","81,113","91,115","94,115","115,115","51,117","52,117","53,117","63,117","64,117","65,117","70,117","72,117","73,117","74,117","75,117","76,117","80,117","82,117","83,117","88,117","90,117","79,118","25,119","26,119","39,119","41,119","53,119","63,119","65,119","70,119","74,119","75,119","80,119","88,119","79,120","88,121","97,121","100,121","104,121","105,121","39,124","41,124","48,124","51,124","52,124","53,124","63,124","64,124","65,124","67,124","69,124","70,124","72,124","73,124","74,124","75,124","76,124","78,124","79,124",
        };

        var walked = new string[]
            { };

        // Arrange
        var world = InputReader.ReadJustin();

        // Act
        world.Simulate(true);
        var total = world.GetLoops();

        // Assert
        var peterPositions = total.Select(x => x.Postion).ToArray();

        var peterWelGevonden = peterPositions.Except(looped);
        var peterNietGevonden = looped.Except(peterPositions);


        total.Select(x => x.Postion).Should().BeEquivalentTo(looped);
    }
}
