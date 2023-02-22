echo "Generating PDF for Reti Logiche"
echo $(pandoc --resource-path=src:src/images src/*.md -o rl.pdf -f markdown-implicit_figures)
