using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day9;

public class InputReader
{
    public static Disk Read()
    {
        var input = FileReader.ReadLines("Day9\\input.txt");

        return Read(input[0]);
    }

    public static Disk Read(string line)
    {
        var disk = new Disk();

        for (var i = 0; i < line.Length; i++)
        {
            var isFile = i % 2 == 0;
            var number = int.Parse(line[i].ToString());

            if (isFile)
                disk.WriteFile(number);
            else
                disk.WriteEmptyBlock(number);
        }

        return disk;
    }
}

public class Disk
{
    private int fileId = -1;
    public List<Block> Blocks = new();
    public List<Block> EmptyBlocks = new();

    public void WriteFile(int length)
    {
        this.fileId++;

        for (var i = 0; i < length; i++)
        {
            this.Blocks.Add(new Block { FileId = this.fileId, Index = this.Blocks.Count });
        }
    }

    public void WriteEmptyBlock(int length)
    {
        if (length == 0)
            return;

        for (var i = 0; i < length; i++)
        {
            var emptyBlock = new Block { Index = this.Blocks.Count };
            this.Blocks.Add(emptyBlock);
            this.EmptyBlocks.Add(emptyBlock);
        }
    }

    public void Compress()
    {
        var index = this.Blocks.Count;

        while (!this.IsCompressed())
        {
            index--;
            this.Compress(index);
        }
    }

    public bool IsCompressed()
    {
        var firstEmptyBlock = this.Blocks.First(x => x.IsEmpty);
        var lastFullBlock = this.Blocks.Last(x => !x.IsEmpty);

        return firstEmptyBlock.Index > lastFullBlock.Index;
    }

    private void Compress(int index)
    {
        var block = this.Blocks[index];

        if (block.FileId == -1)
            return;

        var emptyBlock = this.EmptyBlocks.First();
        this.EmptyBlocks.Remove(emptyBlock);

        emptyBlock.FileId = block.FileId;
        block.Reset();
    }

    public void CompressLarge()
    {
        this.ResetEmptyBlocks();

        var fileId = this.Blocks.Last(x => !x.IsEmpty).FileId + 1;

        while (fileId > 0)
        {
            fileId--;
            this.MoveFile(fileId);
        }
    }

    private void MoveFile(int id)
    {
        var file = this.GetFile(id);

        if (file.Length == 0)
            return;

        var emptyBlocks = this.GetEmptyBlocks(file.Length);

        if (emptyBlocks.Length == 0)
            return;

        if (emptyBlocks.First().Index > file.First().Index)
            return;

        for (var i = 0; i < file.Length; i++)
        {
            emptyBlocks[i].FileId = file[i].FileId;
            file[i].Reset();
            this.EmptyBlocks.Remove(emptyBlocks[i]);
        }
    }

    private Block[] GetFile(int id)
    {
        return this.Blocks.Where(x => x.FileId == id).ToArray();
    }

    private Block[] GetEmptyBlocks(int length)
    {
        if (length == 0)
            return Array.Empty<Block>();

        if (length == 1)
            return new[] { this.EmptyBlocks.First() };

        var blocks = new List<Block>(length);
        var index = -100;

        foreach (var emptyBlock in this.EmptyBlocks)
        {
            // This block is not next to the previous one
            if (index + 1 != emptyBlock.Index)
            {
                blocks.Clear();
                blocks.Add(emptyBlock);
                index = emptyBlock.Index;
                continue;
            }

            blocks.Add(emptyBlock);
            index = emptyBlock.Index;

            if (blocks.Count == length)
            {
                return blocks.ToArray();
            }
        }

        return Array.Empty<Block>();
    }

    private void ResetEmptyBlocks()
    {
        this.EmptyBlocks = this.Blocks.Where(x => x.IsEmpty).ToList();
    }

    public long GetChecksum()
    {
        return this.Blocks.Sum(x => x.GetChecksum());
    }

    public void Print()
    {
        Console.WriteLine(this.ToString());
    }

    public override string ToString()
    {
        return string.Join("", this.Blocks);
    }
}

public class Block
{
    public int FileId { get; set; } = -1;
    public int Index { get; set; }

    public bool IsEmpty => this.FileId == -1;

    public void Reset()
    {
        this.FileId = -1;
    }

    public long GetChecksum()
    {
        if (this.FileId == -1)
            return 0;

        return this.FileId * this.Index;
    }

    public override string ToString()
    {
        return this.FileId != -1 ? this.FileId.ToString() : ".";
    }
}
