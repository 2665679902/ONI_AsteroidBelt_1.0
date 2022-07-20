﻿using ONI_AsteroidBelt_1.WorldCreator.WorldData.World.WorldProfile;
using PLog;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static ONI_AsteroidBelt_1.WorldCreator.Creator;


namespace ONI_AsteroidBelt_1.WorldCreator.CreatorActions
{
    internal class CellsSeparater
    {

        private static void GetRandCenter(out Vector2I center, BiomeLocation location, CommonWorld world)
        {
            int xrand = CreatorRandom.Next(-world.Width / 15, world.Width / 15);
            int yrand = CreatorRandom.Next(-world.Height / 15, world.Height / 15);
            switch (location)
            {
                case BiomeLocation.Middle:
                    center = new Vector2I(world.Width / 2 + xrand, world.Height / 2 + yrand);
                    break;
                case BiomeLocation.Up:
                    center = new Vector2I(world.Width / 2 + xrand, world.Height - Math.Abs(yrand));
                    break;
                case BiomeLocation.Down:
                    center = new Vector2I(world.Width / 2 + xrand, Math.Abs(yrand));
                    break;
                case BiomeLocation.Left:
                    center = new Vector2I(Math.Abs(xrand), world.Height / 2 + yrand);
                    break;
                case BiomeLocation.Right:
                    center = new Vector2I(world.Width - Math.Abs(xrand), world.Height / 2 + yrand);
                    break;
                default:
                    center = new Vector2I(world.Width / 2, world.Height / 2);
                    break;
            }

            if (world is StartWorld start)
            {
                start.Center = center;
            }
        }

        private static void DrawBreakCircule(out HashSet<Vector2I> vectors, int height, int width, Vector2I center, float mincount, float maxcount, int radius)
        {
            vectors = new HashSet<Vector2I>();

            // 返回一个长度为w_width的抖动的int数组
            int[] GetHorizontalWalk(int w_width, int min, int max)
            {
                double WalkChance = 0.7;
                double DoubleWalkChance = 0.25;
                int[] walk = new int[w_width];
                int w_height = CreatorRandom.Next(min, max + 1);
                for (int i = 0; i < walk.Length; i++)
                {
                    if (CreatorRandom.NextDouble() < WalkChance)
                    {
                        int direction;
                        if (w_height >= max)
                            direction = -CreatorRandom.Next(1, 3);
                        else if (w_height <= min)
                            direction = CreatorRandom.Next(1, 3);
                        else
                            direction = CreatorRandom.NextDouble() < 0.5 ? CreatorRandom.Next(1, 3) : -CreatorRandom.Next(1, 3);
                        if (CreatorRandom.NextDouble() < DoubleWalkChance)
                            direction *= 2;
                        w_height = Mathf.Clamp(w_height + direction, min, max);
                    }
                    walk[i] = w_height;
                }
                return walk;
            }

            radius = (int)(radius * 1.4);

            //获取每一个cell到中心点的许可
            int[] radiusWalk = GetHorizontalWalk(radius * radius * 4, (int)(radius * mincount), (int)(radius * maxcount));

            radius = (int)(radius * maxcount) * 4;

            int right = center.X + radius;
            int top = center.Y + radius;

            //验证许可
            for (int i = 1; i < right * 2; i++)
                for (int j = 1; j < top * 2; j++)
                {
                    if (i < width && j < height && (center.X - i) * (center.X - i) + (center.Y - j) * (center.Y - j) < radiusWalk[i] * radiusWalk[i] - CreatorRandom.Next(-3, 3))
                    {
                        vectors.Add(new Vector2I(i, j));
                    }
                }
        }

        private static void PunctateSet(out HashSet<Vector2I> _area, BiomeLocation location, CommonWorld world)
        {
            _area = new HashSet<Vector2I>();

            GetRandCenter(out Vector2I center, location, world);

            List<Vector2I> subCenters = new List<Vector2I>();
            for (int i = 0; i < 2; i++)
            {
                subCenters.Add(new Vector2I(
                    CreatorRandom.Next(center.X - 15 > 1 ? center.X - 15 : 1, center.X + 6 < world.Width-1 ? center.X + 15 : world.Width - 2),
                    CreatorRandom.Next(center.Y - 15 > 1 ? center.Y - 15 : 1, center.Y + 6 < world.Height-1 ? center.Y + 15 : world.Height - 2)
                    ));
            }

            Log.Debug($"PunctateSet -> Get two subCenters: X1: {subCenters[0].X},  Y1: {subCenters[0].Y}, X2: {subCenters[1].X},  Y2: {subCenters[1].Y}");

            foreach (var sub in subCenters)
            {
                DrawBreakCircule(out HashSet<Vector2I> res, world.Height, world.Width, sub, 0.8f, 1.4f, 15);
                foreach (var v in res)
                    _area.Add(v);
            }

            Log.Debug($"Get Inner _area: {_area.Count()}");

            subCenters.Clear();

            for (int i = 0; i < 4; i++)
            {
                subCenters.Add(new Vector2I(
                    CreatorRandom.Next(center.X - 35 > 1 ? center.X - 35 : 1, center.X + 36 < world.Width-1 ? center.X + 35 : world.Width - 2),
                    CreatorRandom.Next(center.Y - 35 > 1 ? center.Y - 35 : 1, center.Y + 36 < world.Height-1 ? center.Y + 35 : world.Height - 2)
                    ));
            }

            foreach (var sub in subCenters)
            {
                DrawBreakCircule(out HashSet<Vector2I> res, world.Height, world.Width, sub, 0.8f, 1.4f, 10);
                foreach (var v in res)
                    _area.Add(v);
            }

            Log.Debug($"OutPut _area: {_area.Count()}");
        }

        private static void BulkSet(out HashSet<Vector2I> _area, BiomeLocation location, CommonWorld world)
        {
            _area = new HashSet<Vector2I>();

            GetRandCenter(out Vector2I center, location, world);

            List<Vector2I> subCenters = new List<Vector2I>();

            for (int i = 0; i < CreatorRandom.Next(2, 4); i++)
            {
                subCenters.Add(new Vector2I(
                    CreatorRandom.Next(center.X - 25 > 0 ? center.X - 25 : 1, center.X + 26 < world.Width-1 ? center.X + 25 : world.Width - 2),
                    CreatorRandom.Next(center.Y - 25 > 0 ? center.Y - 25 : 1, center.Y + 26 < world.Height-1 ? center.Y + 25 : world.Height - 1)
                    ));
            }

            Log.Debug($"BulkSet -> Get two subCenters: X1: {subCenters[0].X},  Y1: {subCenters[0].Y}, X2: {subCenters[1].X},  Y2: {subCenters[1].Y}");

            foreach (var sub in subCenters)
            {
                DrawBreakCircule(out HashSet<Vector2I> res, world.Height, world.Width, sub, 0.8f, 1.4f, 10);
                foreach(var v in res)
                    _area.Add(v);
            }

            Log.Debug($"Get _area: {_area.Count()}");

            var temp = new HashSet<Vector2I>(_area);

            foreach (var vector in temp)
            {
                if (Math.Abs(vector.X - center.X) > 60 || Math.Abs(vector.Y - center.Y) > 60)
                    _area.Remove(vector);
            }

            Log.Debug($"OutPut _area: {_area.Count()}");
        }

        private static void CircularSet(out HashSet<Vector2I> _area, BiomeLocation location, CommonWorld world)
        {

            GetRandCenter(out Vector2I center, location, world);

            DrawBreakCircule(out _area, world.Height, world.Width, center, 0.7f, 1.5f, 20);

        }

        private static void LowFullSet(out HashSet<Vector2I> _area, BiomeLocation location, CommonWorld world)
        {
            _area = new HashSet<Vector2I>();

            for (int i = 1; i < world.Width; i++)
                for (int j = 1; j < (world.Height * 0.3 > 20 ? world.Height * 0.3 : 20); j++)
                    _area.Add(new Vector2I(i, j));
        }


        public static void SeparateCells(CommonWorld world)
        {
            HashSet<Vector2I> total = new HashSet<Vector2I>();
            foreach (var biome in world.Biomes)
            {
                HashSet<Vector2I> area = new HashSet<Vector2I>();
                switch (biome.Pattern)
                {
                    case BehaviorPattern.Circular:
                        CircularSet(out area, biome.Location, world);
                        break;
                    case BehaviorPattern.Bulk:
                        BulkSet(out area, biome.Location, world);
                        break;
                    case BehaviorPattern.Punctate:
                        PunctateSet(out area, biome.Location, world);
                        break;
                    case BehaviorPattern.LowFull:
                        LowFullSet(out area, biome.Location, world);
                        break;
                }

                area.ExceptWith(total);

                Log.Debug($"Final -> Get area: {area.Count}");

                total.Concat(area);

                biome.Cells = area;
            }

            return;

        }
    }
}
