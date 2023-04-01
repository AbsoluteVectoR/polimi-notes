echo "Generating PDF for Philosophical Issues of Computer Science"
echo $(pandoc --resource-path=src:src/images src/*.md -o "philosophical issues.pdf" -f markdown-implicit_figures)
