using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using UnityEngine;

public class Tools
{
    //读取关卡列表
    public static List<FileInfo> GetLevelFiles()
    {
        string[] files = Directory.GetFiles(Consts.LevelDir, "*.xml");

        List<FileInfo> list = new List<FileInfo>();
        for (int i = 0; i < files.Length; i++)
        {
            FileInfo file = new FileInfo(files[i]);
            list.Add(file);
        }
        return list;
    }

    //填充Level类数据
    public static void FillLevel(string fileName, ref Level level)
    {
        FileInfo file = new FileInfo(fileName);
        StreamReader sr = new StreamReader(file.OpenRead(), Encoding.UTF8);

        XmlDocument doc = new XmlDocument();
        doc.Load(sr);

        level.Name = doc.SelectSingleNode("Level/Name").InnerText;
        level.Background = doc.SelectSingleNode("Level/Backround").InnerText;
        level.Road = doc.SelectSingleNode("Level/Road").InnerText;
        level.InitScore=int.Parse(doc.SelectSingleNode("Level/InitScore").InnerText);

        XmlNodeList nodes;
        nodes = doc.SelectNodes("Level/Holder/Point");
        for (int i = 0; i < nodes.Count; i++)
        {
            XmlNode node = nodes[i];
            Point p=new Point(int.Parse(node.Attributes["X"].Value),int.Parse(node.Attributes["Y"].Value));

            level.Holder.Add(p);
        }

        nodes = doc.SelectNodes("Level/Path/Point");
        for (int i = 0; i < nodes.Count; i++)
        {
            XmlNode node = nodes[i];
            Point p = new Point(int.Parse(node.Attributes["X"].Value), int.Parse(node.Attributes["Y"].Value));

            level.Path.Add(p);
        }

        nodes = doc.SelectNodes("Level/Round/Point");
        for (int i = 0; i < nodes.Count; i++)
        {
            XmlNode node = nodes[i];
            Round r = new Round(int.Parse(node.Attributes["Monster"].Value), int.Parse(node.Attributes["Count"].Value));

            level.Rounds.Add(r);
        }

        sr.Close();
        sr.Dispose();
    }

    //加载图片
    public static IEnumerator LoadImage(string url, SpriteRenderer render)
    {
        WWW www = new WWW(url);

        while (!www.isDone)
            yield return www;

        Texture2D texture = www.texture;
        Sprite sp = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
        render.sprite = sp;
    }

}
