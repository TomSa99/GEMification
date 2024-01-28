namespace RedBlueGames.Tools.TextTyper
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using RedBlueGames.Tools.TextTyper;
    using UnityEngine.UI;
    using TMPro;

    /// <summary>
    /// Class that tests TextTyper and shows how to interface with it.
    /// </summary>
    public class TextTyperTester : MonoBehaviour
    {
#pragma warning disable 0649 // Ignore "Field is never assigned to" warning, as these are assigned in inspector
        [SerializeField]
        private AudioClip printSoundEffect;

        [Header("UI References")]

        [SerializeField]
        private Button printNextButton;

        /*[SerializeField]
        private Button printNoSkipButton;*/

        [SerializeField]
        private Toggle pauseGameToggle;

        private Queue<string> dialogueLines = new Queue<string>();

        [SerializeField]
        [Tooltip("The text typer element to test typing with")]
        private TextTyper testTextTyper;

#pragma warning restore 0649
        public void Start()
        {
            this.testTextTyper.PrintCompleted.AddListener(this.HandlePrintCompleted);
            this.testTextTyper.CharacterPrinted.AddListener(this.HandleCharacterPrinted);

            this.printNextButton.onClick.AddListener(this.HandlePrintNextClicked);
            /*this.printNoSkipButton.onClick.AddListener(this.HandlePrintNoSkipClicked);*/

            dialogueLines.Enqueue("Welcome!");
            dialogueLines.Enqueue("Our goal in this laboratory is to genetically modify different type of organisms in order to increase the production of a certain product. " +
                "This is done by manipulating the normal expression of different genes: increasing the expression rate, over-expression; decreasing the expression rate, under-expression; " +
                "or even eliminating genes, deletion. Gene expression involves utilising information from a gene to synthesise a functional gene product, such as proteins or non-coding RNA.");
            dialogueLines.Enqueue("For each target product, from different organisms, we gathered different combinations of modifications to different group of genes that we think will help reach our goal, " +
                "each one of them are organised in tables containing the gene name, the type of modification (over- or under-expression or deletion) and the expression fold, which refers to a measure that " +
                "quantifies how much the expression of a particular gene has increased or decreased relative to a reference condition. Your job is to test each set of modifications in order to find the best one, " +
                "that is, the one that better increases the production of the target.");
            dialogueLines.Enqueue("To do this, you will have to use a set of tools provided in this software: You can search more information for each gene, reaction or metabolite; It is also possible to see " +
                "a metabolic pathway map for the organism, this is a great tool to help visualize the sequence of all the reactions; Use the Expression Rate tool to calculate the new expression values for each " +
                "gene, in order to find the new flux values for each reaction associated to each gene; After that, use the Growth Rate tool to simulate the growth of the organism with the new conditions, " +
                "following a set of rules to set the conditions.");
            /*dialogueLines.Enqueue("You can <size=40>size 40</size> and <size=20>size 20</size>");
            dialogueLines.Enqueue("You can <color=#ff0000ff>color</color> tag <color=#00ff00ff>like this</color>.");
            dialogueLines.Enqueue("Sample Shake Animations: <anim=lightrot>Light Rotation</anim>, <anim=lightpos>Light Position</anim>, <anim=fullshake>Full Shake</anim>\nSample Curve Animations: <animation=slowsine>Slow Sine</animation>, <animation=bounce>Bounce Bounce</animation>, <animation=crazyflip>Crazy Flip</animation>");*/
            ShowScript();
        }

        public void Update()
        {
            UnityEngine.Time.timeScale = this.pauseGameToggle.isOn ? 0.0f : 1.0f;

            if (Input.GetKeyDown(KeyCode.Space))
            {

                var tag = RichTextTag.ParseNext("blah<color=red>boo</color");
                LogTag(tag);
                tag = RichTextTag.ParseNext("<color=blue>blue</color");
                LogTag(tag);
                tag = RichTextTag.ParseNext("No tag in here");
                LogTag(tag);
                tag = RichTextTag.ParseNext("No <color=blueblue</color tag here either");
                LogTag(tag);
                tag = RichTextTag.ParseNext("This tag is a closing tag </bold>");
                LogTag(tag);
            }
        }

        private void HandlePrintNextClicked()
        {
            if (this.testTextTyper.IsSkippable() && this.testTextTyper.IsTyping)
            {
                this.testTextTyper.Skip();
            }
            else
            {
                ShowScript();
            }
        }

        /*private void HandlePrintNoSkipClicked()
        {
            ShowScript();
        }*/

        private void ShowScript()
        {
            if (dialogueLines.Count <= 0)
            {
                return;
            }

            this.testTextTyper.TypeText(dialogueLines.Dequeue());
        }

        private void LogTag(RichTextTag tag)
        {
            if (tag != null)
            {
                Debug.Log("Tag: " + tag.ToString());
            }
        }

        private void HandleCharacterPrinted(string printedCharacter)
        {
            // Do not play a sound for whitespace
            if (printedCharacter == " " || printedCharacter == "\n")
            {
                return;
            }

            var audioSource = this.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = this.gameObject.AddComponent<AudioSource>();
            }

            audioSource.clip = this.printSoundEffect;
            audioSource.Play();
        }

        private void HandlePrintCompleted()
        {
            Debug.Log("TypeText Complete");
        }
    }
}