# Polimi notes 

This is a collection of my notes for various Computer Science and Engineering courses that I attended. The repo includes:
- **Master's degree course notes (Work In Progress):**
    - All notes are in English
    - Some course notes are incomplete since still in progress or boring 
- **Bachelor's degree course notes:**
	- All notes are in Italian, except for Foundations of AI
    - Notes are available only for some courses of the study plan

Keep in mind that these notes were created during periods of desperate studying, utilizing both professor-provided materials and resources from fellow students. They are not intended to be perfect and may be inaccurate and incomplete. If you notice any errors or have additions, feel free to open an issue or send a pull request.

## Main features 

- Every course note is divided in macro subjects plain markdown notes but it has also a PDF well formatted 
- Notes are interconnected through markdown links, allowing for easy navigation and exploration of related topics.
- If you open this repository with Obsidian.md (or similar softwares) you also have a one-click graph visualization of the notes interconnections.

## Courses index

````
├── BSc(italian)
│   ├── Algoritmi e Principi dell'Informatica
│   ├── Analisi 2 (WIP)
│   ├── Basi di Dati
│   ├── Economia e Organizzazione Aziendale
│   ├── Fondamenti di Automatica
│   ├── Fondamenti di Elettronica
│   ├── Foundations of Artificial Intelligence
│   ├── Ingegneria del Software
│   ├── Meccanica
│   ├── Probabilità e Statistica per l'Informatica
│   ├── Reti Logiche
│   └── Sistemi Informativi
└── MSc(english) (WIP)
    ├── Advanced Algorithms and Parallel Programming
    ├── Databases 2
    ├── Formal Languages and Compilers (WIP)
    ├── Foundations of Operation Research (WIP)
    ├── Principles of Programming Languages(WIP)
    └── Software Engineering 2
````

`buildEveryPDFInMSC.sh` and `buildEveryPDFInBSC.sh` generate a PDF file (using Pandoc) from each course notes of respectively, the Master courses and a Bachelor courses. I already run them and I generate new PDFs periodically after some relevant changes. 

### Generic course folder 

````
├── Course_Name.md // index of the course
├── buildCOURSE.sh // script to build PDF file 
└── src 
    ├── 00.Header.md 
    ├── ... .md files divided by course chapters
    ├── ... .md 
    ....
    └── images
        ├── ... .png
        ├── ... .jpg
        ....
````

